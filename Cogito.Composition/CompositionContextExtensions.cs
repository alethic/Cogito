using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
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
            var b = new CompositionBatch();
            b.AddExportedValue<T>(exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExportedValue(contractName, exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractType), () => exportedValue));
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionContext service, string contractName, Type identityType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractName, identityType), () => exportedValue));
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionContext service, T exportedValue)
        {
            var b = new CompositionBatch();
            b.AddPart(exportedValue);
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionContext service, string contractName, T exportedValue)
        {
            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionContext service, Type contractType, object exportedValue)
        {
            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionContext service, Type type, string contractName, object exportedValue)
        {
            throw new NotImplementedException();
        }

        public static T GetExportedValue<T>(this ICompositionContext service)
        {
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
