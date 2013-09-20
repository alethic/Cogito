using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.Contracts;

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
            Contract.Requires<ArgumentNullException>(contractType != null);

            return new ExportDefinition(
                AttributedModelServices.GetContractName(contractType),
                new ExportTypeIdentityMetadata(contractType));
        }

        public static ExportDefinition CreateExportDefinition<T>(string contractName)
        {
            Contract.Requires<ArgumentNullException>(contractName != null);

            return CreateExportDefinition(contractName, typeof(T));
        }

        public static ExportDefinition CreateExportDefinition(string contractName, Type identityType)
        {
            Contract.Requires<ArgumentNullException>(contractName != null);
            Contract.Requires<ArgumentNullException>(identityType != null);

            return new ExportDefinition(
                contractName,
                new ExportTypeIdentityMetadata(identityType));
        }

    }

}
