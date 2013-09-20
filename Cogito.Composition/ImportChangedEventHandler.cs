namespace Cogito.Composition
{

    public delegate void ImportChangedEventHandler<T, TMetadata>(object sender, ImportChangedEventArgs<T, TMetadata> e);

    public delegate void ImportChangedEventHandler<T>(object sender, ImportChangedEventArgs<T> e);

}
