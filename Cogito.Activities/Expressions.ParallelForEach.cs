using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> source, Func<InArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate(body),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Func<InArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate(body),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = source,
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Func<InArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate(body),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Func<InArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate(body),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = Invoke(source),
                Body = Delegate<TElement>(arg => Invoke(body, arg)),
            };
        }

    }

}
