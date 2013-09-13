using System;

namespace ISIS.Web.Mvc
{

    class DelegateDisposable : IDisposable
    {

        Action action;

        public DelegateDisposable(Action action)
        {
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
