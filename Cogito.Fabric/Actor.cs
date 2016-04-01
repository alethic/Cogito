using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Health;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric
{

    /// <summary>
    /// Represents an actor.
    /// </summary>
    public abstract class Actor :
        Microsoft.ServiceFabric.Actors.Runtime.Actor
    {

        readonly Lazy<FabricClient> fabric;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Actor()
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
        protected StatefulServiceContext ServiceInitializationParameters
        {
            get { return ActorService.Context; }
        }

        /// <summary>
        /// Gets the code package activation context passed to the service replica.
        /// </summary>
        protected ICodePackageActivationContext CodePackageActivationContext
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
            Contract.Requires<ArgumentNullException>(sourceId != null);
            Contract.Requires<ArgumentNullException>(property != null);

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

        /// <summary>
        /// Executes the given function with the state object available.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual async Task WithState<TState>(Func<TState, Task> func)
            where TState : new()
        {
            // find existing state
            var c = await StateManager.TryGetStateAsync<TState>("State");
            var state = c.HasValue ? c.Value : new TState();

            // execute func with state
            await func(state);

            // save modified state
            await StateManager.SetStateAsync("State", state);
        }

        /// <summary>
        /// Executes the given function with the state object available.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        protected virtual async Task<TResult> WithState<TState, TResult>(Func<TState, Task<TResult>> func)
            where TState : new()
        {
            // find existing state
            var c = await StateManager.TryGetStateAsync<TState>("State");
            var state = c.HasValue ? c.Value : new TState();

            // execute func with state
            var result = await func(state);

            // save modified state
            await StateManager.SetStateAsync("State", state);

            // return result
            return result;
        }

    }

}
