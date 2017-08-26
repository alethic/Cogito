using System;

namespace Cogito.Collections
{

    /// <summary>
    /// Describes an interval between two values.
    /// </summary>
    public abstract class Interval
    {

        /// <summary>
        /// Creates a new <see cref="Interval"/> instance.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Interval<TPoint> Create<TPoint>(TPoint start, TPoint end)
            where TPoint : IComparable<TPoint>
        {
            if (ReferenceEquals(start, null))
                throw new ArgumentNullException(nameof(start));
            if (ReferenceEquals(end, null))
                throw new ArgumentNullException(nameof(end));

            return new Interval<TPoint>(start, end);
        }

        /// <summary>
        /// Creates a new <see cref="Interval"/> instance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Interval<TValue, TPoint> Create<TValue, TPoint>(TValue value, TPoint start, TPoint end)
            where TPoint : IComparable<TPoint>
        {
            if (ReferenceEquals(start, null))
                throw new ArgumentNullException(nameof(start));
            if (ReferenceEquals(end, null))
                throw new ArgumentNullException(nameof(end));

            return new Interval<TValue, TPoint>(value, start, end);
        }

    }

    /// <summary>
    /// Generic interval between two points.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    public class Interval<TPoint> :
        Interval,
        IInterval<TPoint>
        where TPoint : IComparable<TPoint>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Interval(TPoint start, TPoint end)
        {
            if (ReferenceEquals(start, null))
                throw new ArgumentNullException(nameof(start));
            if (ReferenceEquals(end, null))
                throw new ArgumentNullException(nameof(end));

            Start = start;
            End = end;
        }

        /// <summary>
        /// Gets the starting point of the <see cref="Interval{TPoint}"/>.
        /// </summary>
        public TPoint Start { get; private set; }

        /// <summary>
        /// Gets the ending point of the <see cref="Interval{TPoint}"/>.
        /// </summary>
        public TPoint End { get; private set; }

    }

    /// <summary>
    /// Generic interval between two points which holds data.
    /// </summary>
    /// <typeparam name="TPoint"></typeparam>
    public class Interval<TValue, TPoint> :
        Interval<TPoint>
        where TPoint : IComparable<TPoint>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Interval(TValue value, TPoint start, TPoint end)
            : base(start, end)
        {
            if (ReferenceEquals(start, null))
                throw new ArgumentNullException(nameof(start));
            if (ReferenceEquals(end, null))
                throw new ArgumentNullException(nameof(end));

            Value = value;
        }

        /// <summary>
        /// Gets or sets the value on the interval.
        /// </summary>
        public TValue Value { get; set; }

    }

}
