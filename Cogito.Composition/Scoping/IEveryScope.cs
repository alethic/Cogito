namespace Cogito.Composition.Scoping
{

    /// <summary>
    /// Special scope type that indicates a part is available to all available scopes. Used in conjunction with <see 
    /// cref="Visibility.Local"/> to create a part available to each scope with exports only available to that scope.
    /// </summary>
    public interface IEveryScope
    {



    }

}
