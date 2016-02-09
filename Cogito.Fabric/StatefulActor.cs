using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Health;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;

namespace Cogito.Fabric
{

    /// <summary>
    /// Represents a stateful actor with member <see cref="Microsoft.ServiceFabric.Actors.StatefulActor{TState}.State"/> containing it's reliable state.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class StatefulActor<TState> :
        Microsoft.ServiceFabric.Actors.StatefulActor<TState>
        where TState : class, new()
    {

        readonly Lazy<FabricClient> fabric;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public StatefulActor()
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
        protected StatefulServiceInitializationParameters ServiceInitializationParameters
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
                new StatefulServiceReplicaHealthReport(
                    ServiceInitializationParameters.PartitionId,
                    ServiceInitializationParameters.ReplicaId,
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
            Contract.Requires<ArgumentNullException>(packageName.Length > 0);

            return CodePackageActivationContext.GetConfigurationPackageObject(packageName);
        }

        /// <summary>
        /// Name of the default configuration package.
        /// </summary>
        protected string DefaultConfigurationPackageName
        {
            get { return "Config"; }
        }

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
            Contract.Requires<ArgumentNullException>(packageName.Length > 0);
            Contract.Requires<ArgumentNullException>(sectionName != null);
            Contract.Requires<ArgumentNullException>(sectionName.Length > 0);
            Contract.Requires<ArgumentNullException>(parameterName != null);
            Contract.Requires<ArgumentNullException>(parameterName.Length > 0);

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
            Contract.Requires<ArgumentNullException>(sectionName.Length > 0);
            Contract.Requires<ArgumentNullException>(parameterName != null);
            Contract.Requires<ArgumentNullException>(parameterName.Length > 0);

            return DefaultConfigurationPackage?.Settings.Sections[sectionName]?.Parameters[parameterName]?.Value;
        }

        /// <summary>
        /// Initializes a new <see cref="TState"/> instance.
        /// </summary>
        /// <returns></returns>
        protected virtual TState CreateDefaultState()
        {
            return new TState();
        }

        /// <summary>
        /// Override this method to initialize the members, initialize state or register timers. This method is called
        /// right after the actor is activated and before any method call or reminders are dispatched on it.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnActivateAsync()
        {
            // create default state if not available
            if (State == null)
                State = CreateDefaultState();

            await base.OnActivateAsync();
        }

        /// <summary>
        /// Gets the reminder with the specific name or <c>null</c> if no such reminder is registered.
        /// </summary>
        /// <returns></returns>
        protected IActorReminder TryGetReminder(string reminderName)
        {
            Contract.Requires<ArgumentNullException>(reminderName != null);
            Contract.Requires<ArgumentNullException>(reminderName.Length > 0);

            try
            {
                return GetReminder(reminderName);
            }
            catch
            {
                return null;
            }
        }

    }

}
