﻿using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TException>(Func<TArg1, Task<TException>> func, InArgument<TArg1> arg1, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return Throw(Invoke<TArg1, TException>(func, arg1, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TException>(Func<TArg1, Task<TException>> func, DelegateInArgument<TArg1> arg1, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return Throw(Invoke<TArg1, TException>(func, arg1, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TException>(Func<TArg1, Task<TException>> func, Activity<TArg1> arg1, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));

            return Throw(Invoke<TArg1, TException>(func, arg1, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TException>(Func<TArg1, TArg2, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return Throw(Invoke<TArg1, TArg2, TException>(func, arg1, arg2, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TException>(Func<TArg1, TArg2, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return Throw(Invoke<TArg1, TArg2, TException>(func, arg1, arg2, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TException>(Func<TArg1, TArg2, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));

            return Throw(Invoke<TArg1, TArg2, TException>(func, arg1, arg2, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TException>(Func<TArg1, TArg2, TArg3, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return Throw(Invoke<TArg1, TArg2, TArg3, TException>(func, arg1, arg2, arg3, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TException>(Func<TArg1, TArg2, TArg3, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return Throw(Invoke<TArg1, TArg2, TArg3, TException>(func, arg1, arg2, arg3, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TException>(Func<TArg1, TArg2, TArg3, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));

            return Throw(Invoke<TArg1, TArg2, TArg3, TException>(func, arg1, arg2, arg3, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TException>(Func<TArg1, TArg2, TArg3, TArg4, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TException>(func, arg1, arg2, arg3, arg4, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TException>(Func<TArg1, TArg2, TArg3, TArg4, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TException>(func, arg1, arg2, arg3, arg4, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TException>(Func<TArg1, TArg2, TArg3, TArg4, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TException>(func, arg1, arg2, arg3, arg4, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(func, arg1, arg2, arg3, arg4, arg5, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(func, arg1, arg2, arg3, arg4, arg5, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TException>(func, arg1, arg2, arg3, arg4, arg5, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TException>> func, InArgument<TArg1> arg1, InArgument<TArg2> arg2, InArgument<TArg3> arg3, InArgument<TArg4> arg4, InArgument<TArg5> arg5, InArgument<TArg6> arg6, InArgument<TArg7> arg7, InArgument<TArg8> arg8, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TException>> func, DelegateInArgument<TArg1> arg1, DelegateInArgument<TArg2> arg2, DelegateInArgument<TArg3> arg3, DelegateInArgument<TArg4> arg4, DelegateInArgument<TArg5> arg5, DelegateInArgument<TArg6> arg6, DelegateInArgument<TArg7> arg7, DelegateInArgument<TArg8> arg8, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, displayName), displayName);
        }

        /// <summary>
        /// Throws a <typeparam name="TException"/>.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Throw Throw<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, Task<TException>> func, Activity<TArg1> arg1, Activity<TArg2> arg2, Activity<TArg3> arg3, Activity<TArg4> arg4, Activity<TArg5> arg5, Activity<TArg6> arg6, Activity<TArg7> arg7, Activity<TArg8> arg8, string displayName = null)
            where TException : Exception
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            if (arg1 == null)
                throw new ArgumentNullException(nameof(arg1));
            if (arg2 == null)
                throw new ArgumentNullException(nameof(arg2));
            if (arg3 == null)
                throw new ArgumentNullException(nameof(arg3));
            if (arg4 == null)
                throw new ArgumentNullException(nameof(arg4));
            if (arg5 == null)
                throw new ArgumentNullException(nameof(arg5));
            if (arg6 == null)
                throw new ArgumentNullException(nameof(arg6));
            if (arg7 == null)
                throw new ArgumentNullException(nameof(arg7));
            if (arg8 == null)
                throw new ArgumentNullException(nameof(arg8));

            return Throw(Invoke<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TException>(func, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, displayName), displayName);
        }

    }

}
