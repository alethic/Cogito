using System;
using System.Diagnostics.Contracts;

namespace Cogito.Web.Razor
{

    /// <summary>
    /// Accepts the Razor parser's Tuple attribute notation.
    /// </summary>
    public class AttributeValue
    {

        /// <summary>
        /// Converts a string value to an attribute value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator AttributeValue(Tuple<Tuple<string, int>, Tuple<string, int>, bool> value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            return new AttributeValue(value.Item1.Item1, value.Item2.Item1, value.Item3);
        }

        /// <summary>
        /// Converts an object value to an attribute value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator AttributeValue(Tuple<Tuple<string, int>, Tuple<object, int>, bool> value)
        {
            Contract.Requires<ArgumentNullException>(value != null);
            return new AttributeValue(value.Item1.Item1, value.Item2.Item1, value.Item3);
        }

        readonly string prefix;
        readonly object value;
        readonly bool isLiteral;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="value"></param>
        /// <param name="isLiteral"></param>
        public AttributeValue(string prefix, object value, bool isLiteral)
        {
            Contract.Requires<ArgumentNullException>(prefix != null);
            Contract.Requires<ArgumentNullException>(value != null);

            this.prefix = prefix;
            this.value = value;
            this.isLiteral = isLiteral;
        }

        /// <summary>
        /// Gets the previx of the attribute.
        /// </summary>
        public string Prefix
        {
            get { return prefix; }
        }

        /// <summary>
        /// Gets the value of the attribute.
        /// </summary>
        public object Value
        {
            get { return value; }
        }

        /// <summary>
        /// Gets whether the value is a literal.
        /// </summary>
        public bool IsLiteral
        {
            get { return isLiteral; }
        }

    }

}
