using System;
using System.Activities;
using System.Diagnostics.Contracts;

namespace Cogito.Activities
{
    public static partial class Expressions
    {

        public static ActivityAction Delegate(Func<Activity> create)
        {
            Contract.Requires<ArgumentNullException>(create != null);

            return new ActivityAction()
            {
                Handler = create(),
            };
        }

        public static ActivityAction<TArg> Delegate<TArg>(Func<DelegateInArgument<TArg>, Activity> create)
        {
            Contract.Requires<ArgumentNullException>(create != null);

            var arg = new DelegateInArgument<TArg>();

            return new ActivityAction<TArg>()
            {
                Argument = arg,
                Handler = create(arg),
            };
        }

    }

}
