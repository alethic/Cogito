using System;
using System.Diagnostics.Contracts;

namespace Cogito.Composition
{

    class DelegateDisposable : IDisposable
    {

        Action action;

        public DelegateDisposable(Action action)
        {
            Contract.Requires<ArgumentNullException>(action != null);
            this.action = action;
        }

        public void Dispose()
        {
            if (action != null)
            {
                action();
                action = null;
            }
        }

    }

}
