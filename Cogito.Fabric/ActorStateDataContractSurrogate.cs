using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Cogito.ServiceFabric
{

    /// <summary>
    /// Extends data contract serialization to support common <see cref="StatefulActor"/> objects.
    /// </summary>
    public class ActorDataContractSurrogate :
        IDataContractSurrogate
    {

        readonly static IDataContractSurrogate instance;

        /// <summary>
        /// Gets a reference to the singleton instance.
        /// </summary>
        public static IDataContractSurrogate Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static ActorDataContractSurrogate()
        {
            instance = new ActorDataContractSurrogate();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ActorDataContractSurrogate()
        {

        }

        /// <summary>
        /// Returns the type that should be used instead of <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Type GetDataContractType(Type type)
        {
            // IService types will be serialized as ServiceReference
            if (typeof(IService).IsAssignableFrom(type))
                return typeof(ServiceReference);

            // IActor types will be serialized as ActorReference
            if (typeof(IActor).IsAssignableFrom(type))
                return typeof(ActorReference);

            return type;
        }

        /// <summary>
        /// Converts the object into it's serializable representation.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj == null)
                return null;

            if (obj is IService)
                return ServiceReference.Get(obj);

            if (obj is IActor)
                return ActorReference.Get(obj);

            return obj;
        }

        /// <summary>
        /// Converts the deserialized object into it's true representation.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj == null)
                return null;

            // object is ServiceReference, target is IService, and target is not ServiceReference (which is IService)
            if (obj is ServiceReference && typeof(IService).IsAssignableFrom(targetType) && !typeof(ServiceReference).IsAssignableFrom(targetType))
                return ((ServiceReference)obj).Bind(targetType);

            // object is ActorReference, target is IActor, and target is not ActorReference (which is IActor)
            if (obj is ActorReference && typeof(IActor).IsAssignableFrom(targetType) && !typeof(ActorReference).IsAssignableFrom(targetType))
                return ((ActorReference)obj).Bind(targetType);

            return obj;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {

        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            throw new NotImplementedException();
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            throw new NotImplementedException();
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            throw new NotImplementedException();
        }

    }

}