using System;
using System.Activities;
using System.Activities.Statements;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{

    public static partial class Expressions
    {

        /// <summary>
        /// Returns an <see cref="Activity"/> that invokes the child activity with the specified arguments.
        /// </summary>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="arg"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public static Activity With<TArg>(InArgument<TArg> arg, Func<InArgument<TArg>, Activity> create)
        {
            Contract.Requires<ArgumentNullException>(arg != null);
            Contract.Requires<ArgumentNullException>(create != null);

            var arg_ = new DelegateInArgument<TArg>();

            return new InvokeAction<TArg>()
            {
                Action = new ActivityAction<TArg>()
                {
                    Handler = create(arg_),
                    Argument = arg_,
                },
                Argument = arg,
            };
            
        }

    }

}

