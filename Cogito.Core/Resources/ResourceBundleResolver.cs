namespace Cogito.Resources
{

    public class ResourceBundleResolver
    {

        readonly IResourceBundleQuery bundles;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="bundles"></param>
        public ResourceBundleResolver(
            IResourceBundleQuery bundles)
        {
            this.bundles = bundles;
        }

        //public IEnumerable<IResourceBundle> Resolve(IEnumerable<Expression<Func<IResourceBundle, bool>>> filters)
        //{
        //    var dependencies = filters.SelectMany(i => Expand(i));
        //}

        ///// <summary>
        ///// Expands the given filter into the set of all filters from all dependencies.
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //IQueryable<Expression<Func<IResourceBundle, bool>>> Expand(Expression<Func<IResourceBundle, bool>> filter)
        //{
        //    return bundles
        //        .Where(filter)
        //        .SelectMany(i => i.Dependencies
        //            .SelectMany(j => Expand(j)))
        //        .Prepend(filter)
        //        .AsQueryable();
        //}

    }

}
