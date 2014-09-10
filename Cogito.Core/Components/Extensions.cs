using System;

namespace Cogito.Components
{

    /// <summary>
    /// Various extension methods for working with components.
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// Disposes of this object with the given component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="component"></param>
        /// <returns></returns>
        public static T AttachTo<T>(this T self, IComponent component)
            where T : IDisposable
        {
            component.Attach(self);
            return self;
        }

    }

}
