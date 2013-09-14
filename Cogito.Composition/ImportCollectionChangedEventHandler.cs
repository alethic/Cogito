namespace Cogito.Composition
{

    public delegate void ImportCollectionChangedEventHandler<T, TMetadata>(object sender, ImportCollectionChangedEventArgs<T, TMetadata> e);

    public delegate void ImportCollectionChangedEventHandler<T>(object sender, ImportCollectionChangedEventArgs<T> e);

}
