
using System;
using System.Activities;

namespace Cogito.Activities
{

    public static partial class FuncActivity
    {

        public static FuncActivity<TArg1, TResult> Create<TArg1, TResult>(Func<TArg1, TResult> func, InArgument<TArg1> arg1)
        {
            return new FuncActivity<TArg1, TResult>(func, arg1);
        }

        public static FuncActivity<TArg1, TResult> Create<TArg1, TResult>(Func<TArg1, TResult> func, DelegateInArgument<TArg1> arg1)
        {
            return new FuncActivity<TArg1, TResult>(func, arg1);
        }

        public static FuncActivity<TArg1, TResult> Create<TArg1, TResult>(InArgument<TArg1> arg1, Func<TArg1, TResult> func)
        {
            return new FuncActivity<TArg1, TResult>(func, arg1);
        }

        public static FuncActivity<TArg1, TResult> Create<TArg1, TResult>(DelegateInArgument<TArg1> arg1, Func<TArg1, TResult> func)
        {
            return new FuncActivity<TArg1, TResult>(func, arg1);
        }

        public static FuncActivity<TArg1, TArg2, TResult> Create<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2)
        {
            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static FuncActivity<TArg1, TArg2, TResult> Create<TArg1, TArg2, TResult>(Func<TArg1, TArg2, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2)
        {
            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static FuncActivity<TArg1, TArg2, TResult> Create<TArg1, TArg2, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, Func<TArg1, TArg2, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static FuncActivity<TArg1, TArg2, TResult> Create<TArg1, TArg2, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, Func<TArg1, TArg2, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TResult>(func, arg1, arg2);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Create<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Create<TArg1, TArg2, TArg3, TResult>(Func<TArg1, TArg2, TArg3, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Create<TArg1, TArg2, TArg3, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TResult> Create<TArg1, TArg2, TArg3, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, Func<TArg1, TArg2, TArg3, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TResult>(func, arg1, arg2, arg3);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Create<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Create<TArg1, TArg2, TArg3, TArg4, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Create<TArg1, TArg2, TArg3, TArg4, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> Create<TArg1, TArg2, TArg3, TArg4, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, Func<TArg1, TArg2, TArg3, TArg4, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult>(func, arg1, arg2, arg3, arg4);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(func, arg1, arg2, arg3, arg4, arg5);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14, InArgument<TArg15> arg15)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14, DelegateInArgument<TArg15> arg15)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14, InArgument<TArg15> arg15, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14, DelegateInArgument<TArg15> arg15, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14, InArgument<TArg15> arg15, InArgument<TArg16> arg16)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14, DelegateInArgument<TArg15> arg15, DelegateInArgument<TArg16> arg16)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, InArgument<TArg9> arg9, InArgument<TArg10> arg10, InArgument<TArg11> arg11, InArgument<TArg12> arg12, InArgument<TArg13> arg13, InArgument<TArg14> arg14, InArgument<TArg15> arg15, InArgument<TArg16> arg16, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

        public static FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, DelegateInArgument<TArg9> arg9, DelegateInArgument<TArg10> arg10, DelegateInArgument<TArg11> arg11, DelegateInArgument<TArg12> arg12, DelegateInArgument<TArg13> arg13, DelegateInArgument<TArg14> arg14, DelegateInArgument<TArg15> arg15, DelegateInArgument<TArg16> arg16, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func)
        {
            return new FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 1 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TResult> func = null, InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null)
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
        public FuncActivity(InArgument<TArg1> arg1 = null, OutArgument<TResult> result = null, Func<TArg1, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TResult> Func { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg1> Argument1 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 2 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 3 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 4 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TArg4, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 5 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 6 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 7 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 8 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null)
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
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> func = null)
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
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> Func { get; set; }

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

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 9 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 10 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 11 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 12 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg12> Argument12 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11), context.GetValue(Argument12)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 13 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg12> Argument12 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg13> Argument13 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11), context.GetValue(Argument12), context.GetValue(Argument13)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 14 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg12> Argument12 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg13> Argument13 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg14> Argument14 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11), context.GetValue(Argument12), context.GetValue(Argument13), context.GetValue(Argument14)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 15 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        /// <param name="arg15"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, InArgument<TArg15> arg15 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Argument15 = arg15 ?? new InArgument<TArg15>(default(TArg15));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        /// <param name="arg15"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, InArgument<TArg15> arg15 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Argument15 = arg15 ?? new InArgument<TArg15>(default(TArg15));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg12> Argument12 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg13> Argument13 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg14> Argument14 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg15> Argument15 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11), context.GetValue(Argument12), context.GetValue(Argument13), context.GetValue(Argument14), context.GetValue(Argument15)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


    /// <summary>
    /// Provides an <see cref="Activity"/> that executes the given function with 16 arguments.
    /// </summary>
    public class FuncActivity<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> :
        NativeActivity<TResult>
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public FuncActivity()
        {

        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        /// <param name="arg15"></param>
        /// <param name="result"></param>
        /// <param name="arg16"></param>
        /// <param name="result"></param>
        public FuncActivity(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func = null, InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, InArgument<TArg15> arg15 = null, InArgument<TArg16> arg16 = null, OutArgument<TResult> result = null)
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
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Argument15 = arg15 ?? new InArgument<TArg15>(default(TArg15));
            Argument16 = arg16 ?? new InArgument<TArg16>(default(TArg16));
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="result"></param>
        /// <param name="arg2"></param>
        /// <param name="result"></param>
        /// <param name="arg3"></param>
        /// <param name="result"></param>
        /// <param name="arg4"></param>
        /// <param name="result"></param>
        /// <param name="arg5"></param>
        /// <param name="result"></param>
        /// <param name="arg6"></param>
        /// <param name="result"></param>
        /// <param name="arg7"></param>
        /// <param name="result"></param>
        /// <param name="arg8"></param>
        /// <param name="result"></param>
        /// <param name="arg9"></param>
        /// <param name="result"></param>
        /// <param name="arg10"></param>
        /// <param name="result"></param>
        /// <param name="arg11"></param>
        /// <param name="result"></param>
        /// <param name="arg12"></param>
        /// <param name="result"></param>
        /// <param name="arg13"></param>
        /// <param name="result"></param>
        /// <param name="arg14"></param>
        /// <param name="result"></param>
        /// <param name="arg15"></param>
        /// <param name="result"></param>
        /// <param name="arg16"></param>
        /// <param name="result"></param>
        /// <param name="func"></param>
        public FuncActivity(InArgument<TArg1> arg1 = null, InArgument<TArg2> arg2 = null, InArgument<TArg3> arg3 = null, InArgument<TArg4> arg4 = null, InArgument<TArg5> arg5 = null, InArgument<TArg6> arg6 = null, InArgument<TArg7> arg7 = null, InArgument<TArg8> arg8 = null, InArgument<TArg9> arg9 = null, InArgument<TArg10> arg10 = null, InArgument<TArg11> arg11 = null, InArgument<TArg12> arg12 = null, InArgument<TArg13> arg13 = null, InArgument<TArg14> arg14 = null, InArgument<TArg15> arg15 = null, InArgument<TArg16> arg16 = null, OutArgument<TResult> result = null, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> func = null)
        {
            Argument1 = arg1 ?? new InArgument<TArg1>(default(TArg1));
            Argument2 = arg2 ?? new InArgument<TArg2>(default(TArg2));
            Argument3 = arg3 ?? new InArgument<TArg3>(default(TArg3));
            Argument4 = arg4 ?? new InArgument<TArg4>(default(TArg4));
            Argument5 = arg5 ?? new InArgument<TArg5>(default(TArg5));
            Argument6 = arg6 ?? new InArgument<TArg6>(default(TArg6));
            Argument7 = arg7 ?? new InArgument<TArg7>(default(TArg7));
            Argument8 = arg8 ?? new InArgument<TArg8>(default(TArg8));
            Argument9 = arg9 ?? new InArgument<TArg9>(default(TArg9));
            Argument10 = arg10 ?? new InArgument<TArg10>(default(TArg10));
            Argument11 = arg11 ?? new InArgument<TArg11>(default(TArg11));
            Argument12 = arg12 ?? new InArgument<TArg12>(default(TArg12));
            Argument13 = arg13 ?? new InArgument<TArg13>(default(TArg13));
            Argument14 = arg14 ?? new InArgument<TArg14>(default(TArg14));
            Argument15 = arg15 ?? new InArgument<TArg15>(default(TArg15));
            Argument16 = arg16 ?? new InArgument<TArg16>(default(TArg16));
            Result = result;
            Func = func;
        }

        /// <summary>
        /// Gets or sets the function to be invoked.
        /// </summary>
        public Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15, TArg16, TResult> Func { get; set; }

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

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg9> Argument9 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg10> Argument10 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg11> Argument11 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg12> Argument12 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg13> Argument13 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg14> Argument14 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg15> Argument15 { get; set; }

        /// <summary>
        /// Argument to send to function.
        /// </summary>
        [RequiredArgument]
        public InArgument<TArg16> Argument16 { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, Func(context.GetValue(Argument1), context.GetValue(Argument2), context.GetValue(Argument3), context.GetValue(Argument4), context.GetValue(Argument5), context.GetValue(Argument6), context.GetValue(Argument7), context.GetValue(Argument8), context.GetValue(Argument9), context.GetValue(Argument10), context.GetValue(Argument11), context.GetValue(Argument12), context.GetValue(Argument13), context.GetValue(Argument14), context.GetValue(Argument15), context.GetValue(Argument16)));
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);

            if (Func == null)
                metadata.AddValidationError("Func is required.");
        }

    }


}

