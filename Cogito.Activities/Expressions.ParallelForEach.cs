using System;
using System.Activities;
using System.Activities.Expressions;
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
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<IEnumerable<TElement>>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<IEnumerable<TElement>>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<IEnumerable<TElement>>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(IEnumerable<TElement> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<IEnumerable<TElement>>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
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
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<IEnumerable<TElement>> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
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
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<IEnumerable<TElement>> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<IEnumerable<TElement>> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<IEnumerable<TElement>>> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<TElement[]>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<TElement[]>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<TElement[]>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(TElement[] source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(new Literal<TElement[]>(source), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
                Values = As<TElement[], IEnumerable<TElement>>(source, displayName),
                Body = body,
            };
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(DelegateInArgument<TElement[]> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);


            return ParallelForEach(source, Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return new ParallelForEach<TElement>()
            {
                DisplayName = displayName,
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
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(this Activity<TElement[]> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(source, Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<TElement[]> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Func<DelegateInArgument<TElement>, Activity> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate(body), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, ActivityAction<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), body, displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Action<TElement> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

        /// <summary>
        /// Executes <paramref name="body"/> for each element in <paramref name="source"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public static ParallelForEach<TElement> ParallelForEach<TElement>(Func<Task<TElement[]>> source, Func<TElement, Task> body, [CallerMemberName] string displayName = null)
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Requires<ArgumentNullException>(body != null);

            return ParallelForEach(Invoke(source, displayName), Delegate<TElement>(arg => Invoke(body, arg, displayName)), displayName);
        }

    }

}
