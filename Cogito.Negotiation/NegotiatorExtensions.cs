using System;
using System.Diagnostics.Contracts;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides methods for working with <see cref="INegotiator"/> instances.
    /// </summary>
    public static class NegotiatorExtensions
    {

        /// <summary>
        /// Indicates that the negotiator requires a given input type.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TNegotiator OfType<TNegotiator>(this TNegotiator self, Type type)
            where TNegotiator : ISourceNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(type != null);

            self.Contracts.Add(new TypeSourceContract(type));
            return self;
        }

        /// <summary>
        /// Indicates that the negotiator requires a given input type.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TNegotiator OfType<TSource, TNegotiator>(this TNegotiator self)
            where TNegotiator : ISourceNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.Contracts.Add(new TypeSourceContract(typeof(TSource)));
            return self;
        }

        /// <summary>
        /// Indicates that the negotiator requires a given input type.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ISourceNegotiator OfType<TSource>(this ISourceNegotiator self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            OfType<TSource, ISourceNegotiator>(self);
            return self;
        }

        /// <summary>
        /// Indicates that the negotiator produces a given output type.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TNegotiator AsType<TNegotiator>(this TNegotiator self, Type type)
            where TNegotiator : IOutputNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);
            Contract.Requires<ArgumentNullException>(type != null);

            self.Contracts.Add(new TypeOutputContract(type));
            return self;
        }

        /// <summary>
        /// Indicates that the negotiator produces a given output type.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TNegotiator AsType<TOutput, TNegotiator>(this TNegotiator self)
            where TNegotiator : IOutputNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.Contracts.Add(new TypeOutputContract(typeof(TOutput)));
            return self;
        }

        /// <summary>
        /// Indicates that the negotiator produces a given output type.
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IOutputNegotiator AsType<TOutput>(this IOutputNegotiator self)
        {
            Contract.Requires<ArgumentNullException>(self != null);

            AsType<TOutput, IOutputNegotiator>(self);
            return self;
        }

        /// <summary>
        /// Indicates that the weight of a negotiation is of a given value.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static TNegotiator WithWeight<TNegotiator>(this TNegotiator self, double weight)
            where TNegotiator : IOutputNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.Contracts.Add(new ValueWeightContract(weight));
            return self;
        }

        /// <summary>
        /// Requires a certain media type.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static TNegotiator OfContentType<TNegotiator>(this TNegotiator self, MediaType contentType)
            where TNegotiator : ISourceNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.Contracts.Add(new MediaTypeSourceContract(contentType));
            return self;
        }

        /// <summary>
        /// Produces a certain media type.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static TNegotiator AsContentType<TNegotiator>(this TNegotiator self, MediaType mediaType)
            where TNegotiator : IOutputNegotiator
        {
            Contract.Requires<ArgumentNullException>(self != null);

            self.Contracts.Add(new MediaTypeOutputContract(mediaType));
            return self;
        }

    }

}
