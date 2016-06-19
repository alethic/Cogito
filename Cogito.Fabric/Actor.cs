using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Health;
using System.Threading.Tasks;

using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Cogito.Fabric
{

    /// <summary>
    /// Represents an actor.
    /// </summary>
    public abstract class Actor :
        Microsoft.ServiceFabric.Actors.Runtime.Actor
    {

        static readonly Lazy<FabricClient> fabric;

        /// <summary>
        /// Gets a reference to the <see cref="FabricClient"/>.
        /// </summary>
        static protected FabricClient Fabric
        {
            get { return fabric.Value; }
        }

        /// <summary>
        /// Initializes the static instance.
        /// </summary>
        static Actor()
        {
            fabric = new Lazy<FabricClient>(() => new FabricClient(), true);
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        protected Actor()
        {

        }

        /// <summary>
        /// Gets the initialization parameters passed to the service replica.
        /// </summary>
        protected StatefulServiceContext ServiceContext
        {
            get { return ActorService.Context; }
        }

        /// <summary>
        /// Gets the code package activation context passed to the service replica.
        /// </summary>
        protected ICodePackageActivationContext CodePackageActivationContext
        {
            get { return ServiceContext.CodePackageActivationContext; }
        }

        /// <summary>
        /// Reports the given <see cref="HealthInformation"/>.
        /// </summary>
        /// <param name="healthInformation"></param>
        protected void ReportHealth(HealthInformation healthInformation)
        {
            Fabric.HealthManager.ReportHealth(
                new StatefulServiceReplicaHealthReport(
                    ServiceContext.PartitionId,
                    ServiceContext.ReplicaId,
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
        protected void ReportHealth(string sourceId, string property, HealthState state, string description = null, TimeSpan? timeToLive = null, bool? removeWhenExpired = null)
        {
            Contract.Requires<ArgumentNullException>(sourceId != null);
            Contract.Requires<ArgumentNullException>(property != null);

            var i = new HealthInformation(sourceId, property, state);
            if (description != null)
                i.Description = description;
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
            get { Contract.Requires(DefaultConfigurationPackageName != null); return GetConfigurationPackage(DefaultConfigurationPackageName); }
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
            Contract.Requires<ArgumentNullException>(sectionName != null);
            Contract.Requires<ArgumentNullException>(parameterName != null);

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
            Contract.Requires<ArgumentNullException>(parameterName != null);

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
            catch (ReminderNotFoundException)
            {
                // ignore
            }

            return null;
        }

    }

    /// <summary>
    /// Represents an actor with a default well known state object.
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public abstract class Actor<TState> :
        Actor
    {

        const string DEFAULT_STATE_KEY = "__ActorState__";

        /// <summary>
        /// Gets or sets the state name in which the state object is stored.
        /// </summary>
        protected virtual string StateObjectKey { get; set; } = DEFAULT_STATE_KEY;

        /// <summary>
        /// Gets the actor state object.
        /// </summary>
        protected virtual TState State { get; set; }

        /// <summary>
        /// Creates the default state object.
        /// </summary>
        /// <returns></returns>
        protected virtual Task<TState> CreateDefaultState()
        {
            return Task.FromResult(Activator.CreateInstance<TState>());
        }

        /// <summary>
        /// Override this method to initialize the members.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();
            await LoadStateObject();
        }

        /// <summary>
        /// Loads the state object. This method is invoked as part of the actor activation.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task LoadStateObject()
        {
            var o = await StateManager.TryGetStateAsync<TState>(StateObjectKey);
            State = o.HasValue ? o.Value : await CreateDefaultState();
        }

        /// <summary>
        /// Saves the state object. Invoke this after modifications to the state.
        /// </summary>
        /// <returns></returns>
        protected virtual async Task SaveStateObject()
        {
            if (typeof(TState).IsValueType)
                await StateManager.SetStateAsync(StateObjectKey, State);
            else if (State != null)
                await StateManager.SetStateAsync(StateObjectKey, State);
            else if (await StateManager.ContainsStateAsync(StateObjectKey))
                await StateManager.TryRemoveStateAsync(StateObjectKey);
        }

        /// <summary>
        /// This method is invoked by actor runtime an actor method has finished execution. Override this method for
        /// performing any actions after an actor method has finished execution.
        /// </summary>
        /// <param name="actorMethodContext"></param>
        /// <returns></returns>
        protected override async Task OnPostActorMethodAsync(ActorMethodContext actorMethodContext)
        {
            await SaveStateObject();
            await base.OnPostActorMethodAsync(actorMethodContext);
        }

    }

}
