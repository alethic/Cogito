using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Cogito.Negotiation
{

    /// <summary>
    /// Basic negotiator that accepts a source object and returns an output object.
    /// </summary>
    /// <typeparam name="TAccept"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class Negotiator<TAccept, TOutput> :
        Negotiator
    {

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="func"></param>
        public Negotiator(Func<TAccept, NegotiationContext, TOutput> func)
            : base((_, ctx) => func((TAccept)_, ctx))
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this
                .OfType(typeof(TAccept))
                .AsType(typeof(TOutput));
        }

        public override object Execute(object source, NegotiationContext context)
        {
            Contract.Ensures(Contract.Result<object>() is TOutput);
            Contract.Assert(source is TAccept);

            return base.Execute(source, context);
        }

    }

    /// <summary>
    /// Provided to an <see cref="IConnection"/> so that it may configure its negotiations.
    /// </summary>
    public class Negotiator :
        INegotiator
    {

        #region Connect

        /// <summary>
        /// Returns a generic <see cref="Negotiator"/> that accepts a specific type and returns a specific type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static INegotiator Connect<TSource, TOutput>(Func<TSource, NegotiationContext, TOutput> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new Negotiator<TSource, TOutput>(func);
        }

        /// <summary>
        /// Returns a generic <see cref="Negotiator"/> that accepts a specific type and returns a specific type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static INegotiator Connect<TSource, TOutput>(Func<TSource, TOutput> func)
        {
            Contract.Requires<ArgumentNullException>(func != null);

            return new Negotiator<TSource, TOutput>((_, ctx) => func(_));
        }

        /// <summary>
        /// Returns a generic <see cref="Negotiator"/> that accepts a specific type and returns a specific type.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static INegotiator Connect(Type sourceType, Type outputType, Func<object, NegotiationContext, object> func)
        {
            Contract.Requires<ArgumentNullException>(sourceType != null);
            Contract.Requires<ArgumentNullException>(outputType != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new Negotiator(func)
                .OfType(sourceType)
                .AsType(outputType);
        }

        /// <summary>
        /// Returns a generic <see cref="Negotiator"/> that accepts a specific type and returns a specific type.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="outputType"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static INegotiator Connect(Type sourceType, Type outputType, Func<object, object> func)
        {
            Contract.Requires<ArgumentNullException>(sourceType != null);
            Contract.Requires<ArgumentNullException>(outputType != null);
            Contract.Requires<ArgumentNullException>(func != null);

            return new Negotiator((_, ctx) => func(_))
                .OfType(sourceType)
                .AsType(outputType);
        }

        #endregion

        #region Provide

        /// <summary>
        /// Returns an <see cref="INegotiator"/> that terminates a given type.
        /// </summary>
        /// <returns></returns>
        public static INegotiator Terminate<T>()
        {
            return Negotiator.Connect<T, T>(_ => _);
        }

        #endregion

        /// <summary>
        /// Negotiates a connection between the specified head node and the specified tail node. This means in the
        /// direction of tail from head. Returns <c>null</c> if negotiation fails.
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static NegotiationResult Negotiate(IOutputNegotiator head, ISourceNegotiator tail)
        {
            Contract.Requires<ArgumentNullException>(head != null);
            Contract.Requires<ArgumentNullException>(tail != null);

            // negotiate tail against head
            var a = tail.Negotiate(head.Contracts);
            if (a == null)
                return null;

            // negotiate head against tail
            var b = head.Negotiate(tail.Contracts);
            if (b == null)
                return null;

            // combine weights
            return new NegotiationResult(a.Weight + b.Weight);
        }

        /// <summary>
        /// Negotiates a connection between the specified head node and the specified set of source contracts.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static NegotiationResult Negotiate(IOutputNegotiator head, IEnumerable<ISourceContract> contracts)
        {
            Contract.Requires<ArgumentNullException>(head != null);
            Contract.Requires<ArgumentNullException>(contracts != null);

            // begin compiling weight
            double weight = 0d;

            // source contracts
            foreach (var contract in contracts)
            {
                // negotiate with peer
                var result = contract.Negotiate(head);
                if (result == null)
                    return null;

                // add weight
                weight += result.Weight;
            }

            // successful negotiation
            return new NegotiationResult(weight);
        }

        /// <summary>
        /// Negotiates a connection between the specified tail node and the specified set of output contracts.
        /// </summary>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static NegotiationResult Negotiate(ISourceNegotiator tail, IEnumerable<IOutputContract> contracts)
        {
            Contract.Requires<ArgumentNullException>(tail != null);
            Contract.Requires<ArgumentNullException>(contracts != null);

            // begin compiling weight
            double weight = 0d;

            // source contracts
            foreach (var contract in contracts)
            {
                // negotiate with peer
                var result = contract.Negotiate(tail);
                if (result == null)
                    return null;

                // add weight
                weight += result.Weight;
            }

            // successful negotiation
            return new NegotiationResult(weight);
        }

        readonly Func<object, NegotiationContext, object> func;
        readonly List<ISourceContract> sourceContracts;
        readonly List<IOutputContract> outputContracts;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="outputType"></param>
        /// <param name="func"></param>
        public Negotiator(Func<object, NegotiationContext, object> func)
            : this()
        {
            Contract.Requires<ArgumentNullException>(func != null);

            this.func = func;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Negotiator()
        {
            this.sourceContracts = new List<ISourceContract>();
            this.outputContracts = new List<IOutputContract>();
        }

        /// <summary>
        /// Executes the registered function.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual object Execute(object source, NegotiationContext context)
        {
            return func(source, context);
        }

        /// <summary>
        /// Gets the <see cref="ISourceContract"/>s registered with this <see cref="Negotiator"/>.
        /// </summary>
        ICollection<ISourceContract> ISourceNegotiator.Contracts
        {
            get { return sourceContracts; }
        }

        /// <summary>
        /// Gets the <see cref="IOutputContract"/>s registered with this <see cref="Negotiator"/>.
        /// </summary>
        ICollection<IOutputContract> IOutputNegotiator.Contracts
        {
            get { return outputContracts; }
        }

        NegotiationResult ISourceNegotiator.Negotiate(IEnumerable<IOutputContract> contracts)
        {
            return Negotiate(this, contracts);
        }

        NegotiationResult IOutputNegotiator.Negotiate(IEnumerable<ISourceContract> contracts)
        {
            return Negotiate(this, contracts);
        }

        public bool Cacheable
        {
            get { return true; }
        }

    }

}
