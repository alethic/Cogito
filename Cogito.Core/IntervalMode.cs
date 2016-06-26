namespace Cogito
{

    /// <summary>
    /// Specifies the type of interval comparison.
    /// </summary>
    public enum IntervalMode
    {

        /// <summary>
        /// Returns <c>true</c> for values that match either left or right, or are greater than left the value on the left or less than the value on the right.
        /// </summary>
        Open,

        /// <summary>
        /// Returns <c>true</c> for values that are greater than the value on the left or less than the value on the right.
        /// </summary>
        Closed,

        /// <summary>
        /// Returns <c>true</c> for values that match the value on the left, or are greater than the value on the left or less than the value on the right.
        /// </summary>
        SemiOpenLeft,

        /// <summary>
        /// Returns <c>true</c> for values that match the value on the right, or are greater than the value on the left or greater than the value on the right.
        /// </summary>
        SemiOpenRight,

    }

}
