using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<TArg1, Task> func, InArgument<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<TArg1, Task> func, DelegateInArgument<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<TArg1, Task> func, Activity<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(InArgument<TArg1> arg1, Func<TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(DelegateInArgument<TArg1> arg1, Func<TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(Activity<TArg1> arg1, Func<TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>((context, _arg1) => func(_arg1), arg1);
        }

        
        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<ActivityContext, TArg1, Task> func, InArgument<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<ActivityContext, TArg1, Task> func, DelegateInArgument<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }
        public static AsyncActionActivity<TArg1> Action<TArg1>(Func<ActivityContext, TArg1, Task> func, Activity<TArg1> arg1)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(InArgument<TArg1> arg1, Func<ActivityContext, TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(DelegateInArgument<TArg1> arg1, Func<ActivityContext, TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }

        public static AsyncActionActivity<TArg1> Action<TArg1>(Activity<TArg1> arg1, Func<ActivityContext, TArg1, Task> func)
        {
            return new AsyncActionActivity<TArg1>(func, arg1);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<TArg1, TArg2, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, Func<TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, Func<TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Activity<TArg1> arg1, Activity<TArg2> arg2, Func<TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        
        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<ActivityContext, TArg1, TArg2, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<ActivityContext, TArg1, TArg2, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }
        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Func<ActivityContext, TArg1, TArg2, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2> Action<TArg1, TArg2>(Activity<TArg1> arg1, Activity<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2>(func, arg1, arg2);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<TArg1, TArg2, TArg3, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<ActivityContext, TArg1, TArg2, TArg3, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<ActivityContext, TArg1, TArg2, TArg3, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Func<ActivityContext, TArg1, TArg2, TArg3, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3> Action<TArg1, TArg2, TArg3>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3>(func, arg1, arg2, arg3);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<TArg1, TArg2, TArg3, TArg4, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> Action<TArg1, TArg2, TArg3, TArg4>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> Action<TArg1, TArg2, TArg3, TArg4, TArg5>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> func)
        {
            return new AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }


    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 1 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, Task> action = null, InArgument<TArg1> arg1 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, Func<ActivityContext, TArg1, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 2 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, Func<ActivityContext, TArg1, TArg2, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 3 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, Func<ActivityContext, TArg1, TArg2, TArg3, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 4 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 5 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 6 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 7 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous action with 8 arguments.
    /// </summary>
    public class AsyncActionActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> :
        AsyncTaskCodeActivity
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncActionActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        public AsyncActionActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null)
        {
            Action = action;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        public AsyncActionActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> action = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Action = action;
        }

        /// <summary>
        /// Gets or sets the action to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task> Action { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Argument to send to action.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Argument8 { get; set; }

        protected override Task ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Action(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8));
        }

    }


}

