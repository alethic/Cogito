using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Health;

namespace Cogito.Fabric
{

    /// <summary>
    /// Represents a stateless actor which does not have any state managed by the actors runtime.
    /// </summary>
    public abstract class StatelessActor :
        Microsoft.ServiceFabric.Actors.StatelessActor
    {

        readonly Lazy<FabricClient> fabric;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public StatelessActor()
        {
            this.fabric = new Lazy<FabricClient>(() => new FabricClient(), true);
        }

        /// <summary>
        /// Gets a reference to the <see cref="FabricClient"/>.
        /// </summary>
        protected FabricClient Fabric
        {
            get { return fabric.Value; }
        }

        /// <summary>
        /// Gets the initialization parameters passed to the service replica.
        /// </summary>
        protected StatelessServiceInitializationParameters ServiceInitializationParameters
        {
            get { return ActorService.ServiceInitializationParameters; }
        }

        /// <summary>
        /// Gets the code package activation context passed to the service replica.
        /// </summary>
        protected CodePackageActivationContext CodePackageActivationContext
        {
            get { return ServiceInitializationParameters.CodePackageActivationContext; }
        }

        /// <summary>
        /// Reports the given <see cref="HealthInformation"/>.
        /// </summary>
        /// <param name="healthInformation"></param>
        protected void ReportHealth(HealthInformation healthInformation)
        {
            Fabric.HealthManager.ReportHealth(
                new StatelessServiceInstanceHealthReport(
                    ServiceInitializationParameters.PartitionId,
                    ServiceInitializationParameters.InstanceId,
                    healthInformation));
        }

        /// <summary>
        /// Reports the given set of health information.
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="property"></param>
        /// <param name="state"></param>
        /// <param name="timeToLive"></param>
        /// <param name="removeWhenExpired"></param>
        protected void ReportHealth(string sourceId, string property, HealthState state, TimeSpan? timeToLive = null, bool? removeWhenExpired = null)
        {
            var i = new HealthInformation(sourceId, property, state);
            if (timeToLive != null)
                i.TimeToLive = (TimeSpan)timeToLive;
            if (removeWhenExpired != null)
                i.RemoveWhenExpired = (bool)removeWhenExpired;
            ReportHealth(i);
        }

        /// <summary>
        /// Gets the config package object corresponding to the package name.
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        protected ConfigurationPackage GetConfigurationPackage(string packageName)
        {
            Contract.Requires<ArgumentNullException>(packageName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(packageName));

            return CodePackageActivationContext.GetConfigurationPackageObject(packageName);
        }

        /// <summary>
        /// Name of the default configuration package.
        /// </summary>
        protected string DefaultConfigurationPackageName { get; set; } = "Config";

        /// <summary>
        /// Gets the default config package object.
        /// </summary>
        /// <returns></returns>
        protected ConfigurationPackage DefaultConfigurationPackage
        {
            get { return GetConfigurationPackage(DefaultConfigurationPackageName); }
        }

        /// <summary>
        /// Gets the configuration parameter from the specified section of the specified package.
        /// </summary>
        /// <param name="packageName"></param>
        /// <param name="sectionName"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        protected string GetConfigurationPackageParameterValue(string packageName, string sectionName, string parameterName)
        {
            Contract.Requires<ArgumentNullException>(packageName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(packageName));
            Contract.Requires<ArgumentNullException>(sectionName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(sectionName));
            Contract.Requires<ArgumentNullException>(parameterName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(parameterName));

            return GetConfigurationPackage(packageName)?.Settings.Sections[sectionName]?.Parameters[parameterName]?.Value;
        }

        /// <summary>
        /// Gets the configuration parameter from the specified section.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        protected string GetDefaultConfigurationPackageParameterValue(string sectionName, string parameterName)
        {
            Contract.Requires<ArgumentNullException>(sectionName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(sectionName));
            Contract.Requires<ArgumentNullException>(parameterName != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrWhiteSpace(parameterName));

            return DefaultConfigurationPackage?.Settings.Sections[sectionName]?.Parameters[parameterName]?.Value;
        }

    }

}
