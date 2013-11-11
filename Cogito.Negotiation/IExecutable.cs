namespace Cogito.Negotiation
{

    /// <summary>
    /// Base interface of all negotiators.
    /// </summary>
    public interface IExecutable
    {

        /// <summary>
        /// Executes.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        object Execute(object value, NegotiationContext context);

    }

}
