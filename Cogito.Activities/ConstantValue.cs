using System.Activities;

namespace Cogito.Activities
{

    /// <summary>
    /// Provides a constant value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConstantValue<T> :
        CodeActivity<T>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConstantValue()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        public ConstantValue(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Constant value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected override T Execute(CodeActivityContext context)
        {
            return Value;
        }

    }

}
