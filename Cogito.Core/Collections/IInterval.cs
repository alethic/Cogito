using System;

namespace Cogito.Collections
{

    /// <summary>
    /// Describes a class that has a start and end point.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    public interface IInterval<TPoint>
        where TPoint : IComparable<TPoint>
    {

        /// <summary>
        /// Gets the starting point of the interval.
        /// </summary>
        TPoint Start { get; }

        /// <summary>
        /// Gets the ending point of the interval.
        /// </summary>
        TPoint End { get; }

    }

}
