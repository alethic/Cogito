using System;
using System.Activities;
using System.Activities.Expressions;
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
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<IEnumerable<TElement>>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<IEnumerable<TElement>>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<IEnumerable<TElement>>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<IEnumerable<TElement>>.FromValue(source), body);
        }

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
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate(body));
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

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
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

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);


            return ParallelForEach(source, Delegate(body));
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

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
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

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate(body));
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

            return ParallelForEach(Invoke(source), body);
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

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
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

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate(body));
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

            return ParallelForEach(Invoke(source), body);
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

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
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

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<TElement[]>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<TElement[]>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<TElement[]>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(InArgument<TElement[]>.FromValue(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = new As<TElement[], IEnumerable<TElement>>() { Operand = source },
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
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate(body));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);


            return ParallelForEach(source, Delegate(body));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                Values = As<TElement[], IEnumerable<TElement>>(source),
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
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate(body));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Func<DelegateInArgument<TElement>, Activity> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate(body));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, ActivityAction<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), body);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Action<TElement> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Func<TElement, Task> body)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source), Delegate<TElement>(arg => Invoke(body, arg)));
        }

    }

}
