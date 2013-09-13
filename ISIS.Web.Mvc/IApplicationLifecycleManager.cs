namespace ISIS.Web.Mvc
{

    public interface IApplicationLifecycleManager
    {

        void PreStart();

        void Start();

        void PostStart();

        void Shutdown();

    }

}
