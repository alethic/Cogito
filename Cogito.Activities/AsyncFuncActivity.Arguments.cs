using System;
using System.Activities;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Activities
    {

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, InArgument<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, DelegateInArgument<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<TArg1, Task<TResult>> func, Activity<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(InArgument<TArg1> arg1, Func<TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(DelegateInArgument<TArg1> arg1, Func<TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Activity<TArg1> arg1, Func<TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>((context, _arg1) => func(_arg1), arg1);
        }

        
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<ActivityContext, TArg1, Task<TResult>> func, InArgument<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<ActivityContext, TArg1, Task<TResult>> func, DelegateInArgument<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }
        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Func<ActivityContext, TArg1, Task<TResult>> func, Activity<TArg1> arg1)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(InArgument<TArg1> arg1, Func<ActivityContext, TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(DelegateInArgument<TArg1> arg1, Func<ActivityContext, TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }

        public static AsyncFuncActivity<TArg1, TResult> Invoke<TArg1, TResult>(Activity<TArg1> arg1, Func<ActivityContext, TArg1, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TResult>(func, arg1);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<TArg1, TArg2, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, Func<TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, Func<TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Func<TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>((context, _arg1, _arg2) => func(_arg1, _arg2), arg1, arg2);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<ActivityContext, TArg1, TArg2, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<ActivityContext, TArg1, TArg2, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Func<ActivityContext, TArg1, TArg2, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TResult> Invoke<TArg1, TArg2, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Func<ActivityContext, TArg1, TArg2, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Func<TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>((context, _arg1, _arg2, _arg3) => func(_arg1, _arg2, _arg3), arg1, arg2, arg3);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> Invoke<TArg1, TArg2, TArg3, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>((context, _arg1, _arg2, _arg3, _arg4) => func(_arg1, _arg2, _arg3, _arg4), arg1, arg2, arg3, arg4);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5) => func(_arg1, _arg2, _arg3, _arg4, _arg5), arg1, arg2, arg3, arg4, arg5);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6), arg1, arg2, arg3, arg4, arg5, arg6);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>((context, _arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8) => func(_arg1, _arg2, _arg3, _arg4, _arg5, _arg6, _arg7, _arg8), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func)
        {
            return new AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }


    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 1 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 2 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 3 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 4 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 5 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 6 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 7 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7));
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given asynchronous function with 8 arguments.
    /// </summary>
    public class AsyncFuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> :
        AsyncTaskCodeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public AsyncFuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        public AsyncFuncActivity(Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null)
        {
            Func = func;
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public AsyncFuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null, Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        [RequiredArgument]
        public Func<ActivityContext, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TResult>> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg2> Argument2 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg3> Argument3 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg4> Argument4 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg5> Argument5 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg6> Argument6 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg7> Argument7 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg8> Argument8 { get; set; }

        protected override Task<TResult> ExecuteAsync(AsyncCodeActivityContext context)
        {
            return Func(context, context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8));
        }

    }


}

