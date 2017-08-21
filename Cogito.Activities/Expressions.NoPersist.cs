using System;
using System.Activities;
using System.Activities.Statements;

namespace Cogito.Activities
{

    public static partial class NoPersist
    {

        /// <summary>
        /// <summary>
        /// Executes the <paramref name="body"/> under a <see cref="NoPersistScope"/>.
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static NoPersistScope WithNoPersist(this Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            return new NoPersistScope()
            {
                Body = activity,
            };
        }

    }

}
