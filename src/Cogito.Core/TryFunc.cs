namespace Cogito
{

    /// <summary>
    /// Describes a function which attempts to return an output value, and returns <c>true</c> if successful.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="p1"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public delegate bool TryFunc<T, TResult>(T p1, out TResult result);

}
