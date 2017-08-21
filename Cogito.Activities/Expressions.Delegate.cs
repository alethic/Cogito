using System;
using System.Activities;

namespace Cogito.Activities
{
    public static partial class Expressions
    {

        public static ActivityAction Delegate(Func<Activity> create)
        {
            if (create == null)
                throw new ArgumentNullException(nameof(create));

            return new ActivityAction()
            {
                Handler = create(),
            };
        }

        public static ActivityAction<TArg> Delegate<TArg>(Func<DelegateInArgument<TArg>, Activity> create)
        {
            if (create == null)
                throw new ArgumentNullException(nameof(create));

            var arg = new DelegateInArgument<TArg>();

            return new ActivityAction<TArg>()
            {
                Argument = arg,
                Handler = create(arg),
            };
        }

    }

}
