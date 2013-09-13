using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace Cogito.Composition.Metadata
{

    public static class ExportMetadataServices
    {

        public static ExportDefinition CreateExportDefinition<T>()
        {
            return CreateExportDefinition(typeof(T));
        }

        public static ExportDefinition CreateExportDefinition(Type contractType)
        {
            return new ExportDefinition(
                AttributedModelServices.GetContractName(contractType),
                new ExportTypeIdentityMetadata(contractType));
        }

        public static ExportDefinition CreateExportDefinition<T>(string contractName)
        {
            return CreateExportDefinition(contractName, typeof(T));
        }

        public static ExportDefinition CreateExportDefinition(string contractName, Type identityType)
        {
            return new ExportDefinition(
                contractName,
                new ExportTypeIdentityMetadata(identityType));
        }

    }

}
