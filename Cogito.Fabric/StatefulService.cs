using System;
using System.Diagnostics.Contracts;
using System.Fabric;
using System.Fabric.Health;
using System.Threading;
using System.Threading.Tasks;

namespace Cogito.Fabric
{

    /// <summary>
    /// Reliable service base class which provides an <see cref="Microsoft.ServiceFabric.Data.IReliableStateManager"/> and provides some additional utility methods.
    /// </summary>
    public abstract class StatefulService :
        Microsoft.ServiceFabric.Services.Runtime.StatefulService,
        IDisposable
    {

        readonly Lazy<FabricClient> fabric;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public StatefulService(StatefulServiceContext context)
            : base(context)
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
        /// Reports the given <see cref="HealthInformation"/>.
        /// </summary>
        /// <param name="healthInformation"></param>
        protected void ReportHealth(HealthInformation healthInformation)
        {
            Fabric.HealthManager.ReportHealth(
                new StatefulServiceReplicaHealthReport(
                    Context.PartitionId,
                    Context.ReplicaId,
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
        /// Default implementation of RunAsync. Configures the service and dispatches to the RunTaskAsync method until
        /// canceled.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected sealed override async Task RunAsync(CancellationToken cancellationToken)
        {
            // subscribe to configuration package changes
            CodePackageActivationContext.ConfigurationPackageModifiedEvent += CodePackageActivationContext_ConfigurationPackageModifiedEvent;

            // enter method
            await RunEnterAsync(cancellationToken);

            // repeat run task until signaled to exit
            while (!cancellationToken.IsCancellationRequested)
                await RunLoopAsync(cancellationToken);

            // exit method
            await RunExitAsync(new CancellationTokenSource(TimeSpan.FromMinutes(5)).Token);

            // unsubscribe from configuration package changes
            CodePackageActivationContext.ConfigurationPackageModifiedEvent -= CodePackageActivationContext_ConfigurationPackageModifiedEvent;
        }

        /// <summary>
        /// Invoked when the service is run.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task RunEnterAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Invoked when the service is exiting.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task RunExitAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// Override this method to implement the run loop.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task RunLoopAsync(CancellationToken cancellationToken)
        {
            return Task.Delay(TimeSpan.FromSeconds(1));
        }

        /// <summary>
        /// <see cref="Uri"/> of the application this <see cref="StatefulService"/> is a part of.
        /// </summary>
        protected Uri ApplicationName
        {
            get { return new Uri(CodePackageActivationContext.ApplicationName + "/"); }
        }

        /// <summary>
        /// Gets the code package activation context passed to the service replica.
        /// </summary>
        protected ICodePackageActivationContext CodePackageActivationContext
        {
            get { return Context.CodePackageActivationContext; }
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
        /// Invoked when the configuration packages are changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> args)
        {
            OnConfigurationPackageAvailableOrModified(args.NewPackage);
        }

        /// <summary>
        /// Invoked when the available configuration packages become available or changes.
        /// </summary>
        protected virtual void OnConfigurationPackageAvailableOrModified(ConfigurationPackage package)
        {

        }

        /// <summary>
        /// Disposes of the instance.
        /// </summary>
        public void Dispose()
        {
            if (fabric.IsValueCreated)
                fabric.Value.Dispose();
        }

    }

}
