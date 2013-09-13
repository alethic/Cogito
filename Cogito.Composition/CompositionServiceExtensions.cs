
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace ISIS.Web.Mvc
{

    public static class CompositionServiceExtensions
    {

        public static void AddExportedValue<T>(this ICompositionService service, T exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExportedValue<T>(exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue<T>(this ICompositionService service, string contractName, T exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExportedValue(contractName, exportedValue);
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionService service, Type contractType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractType), () => exportedValue));
            service.Compose(b);
        }

        public static void AddExportedValue(this ICompositionService service, string contractName, Type identityType, object exportedValue)
        {
            var b = new CompositionBatch();
            b.AddExport(new Export(ExportMetadataServices.CreateExportDefinition(contractName, identityType), () => exportedValue));
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionService service, T exportedValue)
        {
            var b = new CompositionBatch();
            b.AddPart(exportedValue);
            service.Compose(b);
        }

        public static void ComposeExportedValue<T>(this ICompositionService service, string contractName, T exportedValue)
        {
            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionService service, Type contractType, object exportedValue)
        {
            throw new NotImplementedException();
        }

        public static void ComposeExportedValue(this ICompositionService service, Type type, string contractName, object exportedValue)
        {
            throw new NotImplementedException();
        }

        public static T GetExportedValue<T>(this ICompositionService service)
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

        public static T GetExportedValue<T>(this ICompositionService service, string contractName)
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

        public static T GetExportedValueOrDefault<T>(this ICompositionService service)
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

        public static T GetExportedValueOrDefault<T>(this ICompositionService service, string contractName)
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

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionService service)
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

        public static IEnumerable<T> GetExportedValues<T>(this ICompositionService service, string contractName)
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

        public static Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionService service)
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

        public static Lazy<T, TMetadataView> GetExport<T, TMetadataView>(this ICompositionService service, string contractName)
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

        public static IEnumerable<Lazy<T>> GetExports<T>(this ICompositionService service)
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

        public static IEnumerable<Lazy<T>> GetExports<T>(this ICompositionService service, string contractName)
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

        public static object GetExportedValue(this ICompositionService service, Type contractType)
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

        public static object GetExportedValue(this ICompositionService service, Type type, string contractName)
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

        public static object GetExportedValueOrDefault(this ICompositionService service, Type contractType)
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

        public static object GetExportedValueOrDefault(this ICompositionService service, Type type, string contractName)
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

        public static IEnumerable<object> GetExportedValues(this ICompositionService service, Type contractType)
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

        public static IEnumerable<object> GetExportedValues(this ICompositionService service, Type type, string contractName)
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

        public static Lazy<object, IDictionary<string, object>> GetExport(this ICompositionService service, Type contractType)
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

        public static Lazy<object, IDictionary<string, object>> GetExport(this ICompositionService service, Type type, string contractName)
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

        public static IEnumerable<Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionService service, Type contractType)
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

        public static IEnumerable<Lazy<object, IDictionary<string, object>>> GetExports(this ICompositionService service, Type type, string contractName)
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
