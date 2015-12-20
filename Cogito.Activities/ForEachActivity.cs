using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static ForEachActionActivity<TElement> ForEach<TElement>(InArgument<IEnumerable<TElement>> source, Action<TElement> action)
        {
            return new ForEachActionActivity<TElement>(source, action);
        }

        public static ForEachAsyncActionActivity<TElement> ForEach<TElement>(InArgument<IEnumerable<TElement>> source, Func<TElement, Task> action)
        {
            return new ForEachAsyncActionActivity<TElement>(source, action);
        }

        public static ForEachActionActivity<TElement> ForEach<TElement>(InArgument<TElement[]> source, Action<TElement> action)
        {
            return new ForEachActionActivity<TElement>(FuncActivity.Create<TElement[], IEnumerable<TElement>>(i => i, source), action);
        }

        public static ForEachAsyncActionActivity<TElement> ForEach<TElement>(InArgument<TElement[]> source, Func<TElement, Task> action)
        {
            return new ForEachAsyncActionActivity<TElement>(FuncActivity.Create<TElement[], IEnumerable<TElement>>(i => i, source), action);
        }

    }

}
