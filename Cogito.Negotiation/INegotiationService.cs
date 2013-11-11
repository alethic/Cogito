using System;
using System.Collections.Generic;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Provides interfaces for interacting with the negotiation service.
    /// </summary>
    public interface INegotiationService
    {

        /// <summary>
        /// Negotiates a path between two types with a specified set of additional negotiators.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <param name="negotiators"></param>
        /// <returns></returns>
        Negotiated<TSource, TOutput> Negotiate<TSource, TOutput>(
            INegotiator head,
            INegotiator tail,
            IEnumerable<INegotiator> negotiators);

        /// <summary>
        /// Negotiates a path between two types, optionally allowing configuration.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="source"></param>
        /// <param name="sourceConfigure"></param>
        /// <param name="outputConfigure"></param>
        /// <returns></returns>
        Negotiated<TSource, TOutput> Negotiate<TSource, TOutput>(
            Action<IOutputNegotiator> sourceConfigure,
            Action<ISourceNegotiator> outputConfigure);

        /// <summary>
        /// Negotiates a path between two types, optionally allowing configuration.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="source"></param>
        /// <param name="sourceType"></param>
        /// <param name="outputType"></param>
        /// <param name="sourceConfigure"></param>
        /// <param name="outputConfigure"></param>
        /// <returns></returns>
        Negotiated Negotiate(
            Type sourceType,
            Type outputType,
            Action<IOutputNegotiator> sourceConfigure,
            Action<ISourceNegotiator> outputConfigure);

    }

}
