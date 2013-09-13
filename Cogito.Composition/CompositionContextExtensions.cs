using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;
using System.Linq;

using Cogito.Composition.Metadata;

namespace Cogito.Composition
{

    /// <summary>
    /// Implements the many convience methods against <see cref="ICompositionContext"/>.
    /// </summary>
    public static class CompositionContextExtensions
    {

        public static void AddExportedValue<T>(this ICompositionContext service, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExportedValue<T>(exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExportedValue(contractName, exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractType), () => exportedValue));
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionContext service, string contractName, Type identityType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(identityType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractName, identityType), () => exportedValue));
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionContext service, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            var b = new CompositionBatch();
            b.AddPart(exportedValue);
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionContext service, Type type, string contractName, object exportedValue)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));
            Contract.Requires<ArgumentNullException>(exportedValue != null);

            throw new NotImplementedException();
        }

        public static T GetExportedValue<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value)
                .FirstOrDefault();
        }

        public static T GetExportedValue<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value)
                .FirstOrDefault();
        }

        public static T GetExportedValueOrDefault<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ZeroOrOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value)
                .FirstOrDefault();
        }

        public static T GetExportedValueOrDefault<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ZeroOrOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value)
                .FirstOrDefault();
        }

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value);
        }

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => (T)i.Value);
        }

        public static Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<T, TMetadataView>(() => (T)i.Value, AttributedModelServices.GetMetadataView<TMetadataView>(i.Metadata)))
                .FirstOrDefault();
        }

        public static Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<T, TMetadataView>(() => (T)i.Value, AttributedModelServices.GetMetadataView<TMetadataView>(i.Metadata)))
                .FirstOrDefault();
        }

        public static IEnumerable<Lazy<T>> GetExports<T>(this ICompositionContext service)
        {
            Contract.Requires<ArgumentNullException>(service != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(typeof(T)),
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<T>(() => (T)i.Value));
        }

        public static IEnumerable<Lazy<T>> GetExports<T>(this ICompositionContext service, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(typeof(T)),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<T>(() => (T)i.Value));
        }

        public static object GetExportedValue(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(contractType),
                    null,
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        public static object GetExportedValue(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        public static object GetExportedValueOrDefault(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(contractType),
                    null,
                    null,
                    ImportCardinality.ZeroOrOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        public static object GetExportedValueOrDefault(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ZeroOrOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value)
                .FirstOrDefault();
        }

        public static IEnumerable<object> GetExportedValues(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(contractType),
                    null,
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value);
        }

        public static IEnumerable<object> GetExportedValues(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => i.Value);
        }

        public static Lazy<object, IDictionary<string, object>> GetExport(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(contractType),
                    null,
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<object, IDictionary<string, object>>(() => i.Value, i.Metadata))
                .FirstOrDefault();
        }

        public static Lazy<object, IDictionary<string, object>> GetExport(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ExactlyOne,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<object, IDictionary<string, object>>(() => i.Value, i.Metadata))
                .FirstOrDefault();
        }

        public static IEnumerable<Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionContext service, Type contractType)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(contractType != null);

            return service.GetExports(new ContractBasedImportDefinition(
                    AttributedModelServices.GetContractName(contractType),
                    null,
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<object, IDictionary<string, object>>(() => i.Value, i.Metadata));
        }

        public static IEnumerable<Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionContext service, Type type, string contractName)
        {
            Contract.Requires<ArgumentNullException>(service != null);
            Contract.Requires<ArgumentNullException>(type != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(contractName));

            return service.GetExports(new ContractBasedImportDefinition(
                    contractName,
                    AttributedModelServices.GetTypeIdentity(type),
                    null,
                    ImportCardinality.ZeroOrMore,
                    false,
                    true,
                    CreationPolicy.Any))
                .Select(i => new Lazy<object, IDictionary<string, object>>(() => i.Value, i.Metadata));
        }

    }

}
