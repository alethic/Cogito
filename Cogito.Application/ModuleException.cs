using System;
using System.Diagnostics.Contracts;

namespace Cogito.Application
{

    /// <summary>
    /// Exception specific to a module.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModuleException<T> : 
        Exception
        where T : IModule
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        public ModuleException(T module)
        {
            Contract.Requires<ArgumentNullException>(module != null);

            Module = module;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        public ModuleException(T module, string message)
            : base(message)
        {
            Contract.Requires<ArgumentNullException>(module != null);

            Module = module;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public ModuleException(T module, string format, params object[] args)
            : base(string.Format(format, args))
        {
            Contract.Requires<ArgumentNullException>(module != null);

            Module = module;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ModuleException(T module, string message, Exception innerException)
            : base(message, innerException)
        {
            Contract.Requires<ArgumentNullException>(module != null);

            Module = module;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="innerException"></param>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public ModuleException(T module, Exception innerException, string format, params object[] args)
            : base(string.Format(format, args), innerException)
        {
            Contract.Requires<ArgumentNullException>(module != null);

            Module = module;
        }

        /// <summary>
        /// The module that the exception is related to.
        /// </summary>
        public T Module { get; private set; }

    }

}
