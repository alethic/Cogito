using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values, displayName),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values, displayName),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(InArgument<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = values,
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);


            return ParallelForEach(values, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(values),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(values, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, Func<DelegateInArgument<TElement>, Activity> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, ActivityAction<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, Action<TElement> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="values"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="values"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> values, Func<TElement, Task> body, string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(values != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(values, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

    }

}
