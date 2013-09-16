using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

using Cogito.Composition.Metadata;

namespace Cogito.Composition
{

    /// <summary>
    /// Implements the many convience methods against <see cref="ICompositionContext"/>.
    /// </summary>
    public static class CompositionContextExtensions
    {

        static readonly ConcurrentDictionary<string, Delegate> cache =
            new ConcurrentDictionary<string, Delegate>();

        public static ICompositionContext AddExportedValue<T>(this ICompositionContext service, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExportedValue<T>(exportedValue);
            service.Compose(b);

            return service;
        }

        public static ICompositionContext AddExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExportedValue(contractName, exportedValue);
            service.Compose(b);

            return service;
        }

        public static ICompositionContext AddExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractType), () => exportedValue));
            service.Compose(b);

            return service;
        }

        public static ICompositionContext AddExportedValue(this ICompositionContext service, string contractName, Type identityType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(identityType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractName, identityType), () => exportedValue));
            service.Compose(b);

            return service;
        }

        public static ICompositionContext ComposeExportedValue<T>(this ICompositionContext service, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddPart(exportedValue);
            service.Compose(b);

            return service;
        }

        public static ICompositionContext ComposeExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static ICompositionContext ComposeExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static ICompositionContext ComposeExportedValue(this ICompositionContext service, Type type, string contractName, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static T GetExportedValue<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return ((CompositionContainer)service).GetExportedValue<T>();
        }

        public static T GetExportedValue<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return ((CompositionContainer)service).GetExportedValue<T>(contractName);
        }

        public static T GetExportedValueOrDefault<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return ((CompositionContainer)service).GetExportedValueOrDefault<T>();
        }

        public static T GetExportedValueOrDefault<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return ((CompositionContainer)service).GetExportedValueOrDefault<T>(contractName);
        }

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return ((CompositionContainer)service).GetExportedValues<T>();
        }

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return ((CompositionContainer)service).GetExportedValues<T>(contractName);
        }

        public static System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return ((CompositionContainer)service).GetExport<T, TMetadataView>();
        }

        public static System.Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return ((CompositionContainer)service).GetExport<T, TMetadataView>(contractName);
        }

        public static IEnumerable<System.Lazy<T>> GetExports<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return ((CompositionContainer)service).GetExports<T>();
        }

        public static IEnumerable<System.Lazy<T>> GetExports<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return ((CompositionContainer)service).GetExports<T>(contractName);
        }

        public static object GetExportedValue(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValue",
                    new[] { contractType },
                    p1),
                p1);

            return cache.GetOrAdd(
                    lm.ToString(), 
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static object GetExportedValue(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValue",
                    new[] { type },
                    p1, p2),
                p1, p2);

            return cache.GetOrAdd(
                    lm.ToString(),
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static object GetExportedValueOrDefault(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValueOrDefault",
                    new[] { contractType },
                    p1),
                p1);

            return cache.GetOrAdd(
                    lm.ToString(),
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static object GetExportedValueOrDefault(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValueOrDefault",
                    new[] { type },
                    p1, p2),
                p1, p2);

            return cache.GetOrAdd(
                    lm.ToString(),
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static IEnumerable<object> GetExportedValues(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValues",
                    new[] { contractType },
                    p1),
                p1);

            return (IEnumerable<object>)cache.GetOrAdd(
                    lm.ToString(),
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static IEnumerable<object> GetExportedValues(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            var p1 = Expression.Parameter(typeof(ICompositionContext));
            var p2 = Expression.Parameter(typeof(string));
            var lm = Expression.Lambda(
                Expression.Call(
                    typeof(CompositionContextExtensions),
                    "GetExportedValues",
                    new[] { type },
                    p1, p2),
                p1, p2);

            return (IEnumerable<object>)cache.GetOrAdd(
                    lm.ToString(),
                    _ => lm.Compile())
                .DynamicInvoke(service);
        }

        public static System.Lazy<object, IDictionary<string, object>> GetExport(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            throw new NotImplementedException();
        }

        public static System.Lazy<object, IDictionary<string, object>> GetExport(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            throw new NotImplementedException();
        }

        public static IEnumerable<System.Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            throw new NotImplementedException();
        }

        public static IEnumerable<System.Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            throw new NotImplementedException();
        }

    }

}
