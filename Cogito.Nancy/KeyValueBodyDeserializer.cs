using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

using Cogito.Reflection;

using Nancy;
using Nancy.ModelBinding;

namespace Cogito.Nancy
{

    /// <summary>
    /// Binds available key/value pairs as property expressions.
    /// </summary>
    [Export(typeof(IBodyDeserializer))]
    public class KeyValueBodyDeserializer : IBodyDeserializer
    {

        /// <summary>
        /// Cache of type and property string to setter.
        /// </summary>
        readonly ConcurrentDictionary<Tuple<Type, string>, Tuple<Delegate, Type>> cache =
            new ConcurrentDictionary<Tuple<Type, string>, Tuple<Delegate, Type>>();

        IEnumerable<IKeyValueProvider> keyValueProviders;
        IEnumerable<ITypeConverter> typeConverters;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        [ImportingConstructor]
        public KeyValueBodyDeserializer(
            [ImportMany] IEnumerable<IKeyValueProvider> keyValueProviders,
            [ImportMany] IEnumerable<ITypeConverter> typeConverters)
        {
            this.keyValueProviders = keyValueProviders;
            this.typeConverters = typeConverters;
        }

        /// <summary>
        /// Returns <c>true</c>.
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool CanDeserialize(string contentType, BindingContext context)
        {
            var b = GetSetters(context.Context, context.DestinationType, new string[0])
                .Any();
            return b;
        }

        /// <summary>
        /// Gets all of the key value pairs to be applied.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, object>> GetKeyValuePairs(
            NancyContext context)
        {
            return keyValueProviders
                .SelectMany(i => i.GetKeyValuePairs(context));
        }

        /// <summary>
        /// Creates a <see cref="Delegate"/> that implements the setter specified by the key.
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Tuple<Delegate, Type> KeyToDelegate(
            Type modelType,
            string key)
        {
            Contract.Requires<ArgumentNullException>(modelType != null);
            Contract.Requires<ArgumentNullException>(key != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(key));

            // build lambda to set property expression
            var par1 = Expression.Parameter(modelType, "model");
            var expr = (Expression)par1;

            // navigate through properties
            var path = key.Split('.');
            for (int i = 0; i < path.Length; i++)
            {
                var mi = expr.Type.GetPropertyOrField(path[i], StringComparison.OrdinalIgnoreCase);
                if (mi == null)
                    return null;

                // access member
                expr = Expression.MakeMemberAccess(expr, mi);
            }

            // new value assignment
            var par2 = Expression.Parameter(expr.Type, "value");
            var setr = Expression.Assign(expr, par2);

            // wrap in func
            var func = Expression.Lambda(setr, par1, par2);

            // return setter function and expected type of value
            return Tuple.Create(func.Compile(), expr.Type);
        }

        /// <summary>
        /// Converts the object of the given type to the target type.
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        bool TryConvertTo(
            BindingContext context,
            Type targetType,
            object input,
            out object value)
        {
            Contract.Requires<ArgumentNullException>(context != null);
            Contract.Requires<ArgumentNullException>(targetType != null);

            // already proper type
            if (input != null &&
                input.GetType() == targetType)
            {
                value = input;
                return true;
            }

            // value is null, and target allows it
            if (input == null &&
                targetType.IsClass)
            {
                value = null;
                return true;
            }

            // value is null, and target is value type
            if (input == null &&
                targetType.IsValueType)
            {
                value = Activator.CreateInstance(targetType);
                return true;
            }

            // special bool processing
            if (targetType == typeof(bool))
            {
                var str = input as string;
                if (str != null)
                {
                    if (str == "on")
                    {
                        value = true;
                        return true;
                    }
                    else if (str == "off")
                    {
                        value = true;
                        return false;
                    }
                }
            }

            // using Nancy type converters
            if (input is string)
            {
                // attempt to convert to target
                var conv = typeConverters.FirstOrDefault(i => i.CanConvertTo(targetType, context));
                if (conv != null)
                {
                    try
                    {
                        value = conv.Convert((string)input, targetType, context);
                        return true;
                    }
                    catch (FormatException)
                    {

                    }
                }
            }

            // using framework type converters
            {
                // attempt to convert to target
                var conv = TypeDescriptor.GetConverter(targetType);
                if (conv.CanConvertFrom(input.GetType()))
                {
                    try
                    {
                        value = conv.ConvertFrom(input);
                        return true;
                    }
                    catch (FormatException)
                    {

                    }
                }
            }

            value = null;
            return false;
        }

        /// <summary>
        /// Gets the enumeration of available setters against the given model type.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        IEnumerable<Tuple<Tuple<Delegate, Type>, object>> GetSetters(
            NancyContext context,
            Type modelType,
            string[] blackList)
        {
            return GetKeyValuePairs(context)
                .Where(i => !blackList.Contains(i.Key))
                .Select(i =>
                    Tuple.Create(
                        cache.GetOrAdd(
                            Tuple.Create(modelType, i.Key),
                            _ => KeyToDelegate(_.Item1, _.Item2)),
                        i.Value))
                .Where(i => i.Item1 != null && i.Item1.Item1 != null);
        }

        public object Deserialize(string contentType, Stream bodyStream, BindingContext context)
        {
            object value;
            foreach (var setter in GetSetters(context.Context, context.DestinationType, new string[0]))
                if (TryConvertTo(context, setter.Item1.Item2, setter.Item2, out value))
                    setter.Item1.Item1.DynamicInvoke(context.Model, value);

            return context.Model;
        }

    }

}
