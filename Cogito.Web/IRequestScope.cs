using Cogito.Composition.Scoping;

namespace Cogito.Web
{

    /// <summary>
    /// Deliminates the boundaries of a <see cref="HttpRequest"/>.
    /// </summary>
    public interface IRequestScope :
        IScope,
        ITransactionScope,
        IUserIdentityScope
    {



    }

}
