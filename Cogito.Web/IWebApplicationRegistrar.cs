namespace Cogito.Web
{

    /// <summary>
    /// Provides an entry point to register components with a web application.
    /// </summary>
    public interface IWebApplicationRegistrar
    {

        /// <summary>
        /// Invoked during registration with a web application.
        /// </summary>
        void Register();

    }

}
