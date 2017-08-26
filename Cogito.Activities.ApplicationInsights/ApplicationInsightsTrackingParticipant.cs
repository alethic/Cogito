using System;
using System.Activities.Tracking;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;

namespace Cogito.Activities.ApplicationInsights
{

    /// <summary>
    /// Exports Windows Workflow tracking activities to Application Insights. Add as an extension to a workflow
    /// instance, and initialize with a <see cref="TelemetryClient"/> instance.
    /// </summary>
    public partial class ApplicationInsightsTrackingParticipant :
        TrackingParticipant
    {

        const string ITEMS_ELEMENT = "items";
        const string ITEM_ELEMENT = "item";
        const string NAME_ATTRIBUTE = "name";
        const string TYPE_ATTRIBUTE = "type";

        readonly TelemetryClient telemetryClient;
        readonly string parentOperationId;
        readonly NetDataContractSerializer variableSerializer = new NetDataContractSerializer();

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="telemetryClient"></param>
        /// <param name="parentOperationId"></param>
        public ApplicationInsightsTrackingParticipant(TelemetryClient telemetryClient, string parentOperationId = null)
        {
            this.telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
            this.parentOperationId = parentOperationId;
        }

        /// <summary>
        /// Tracks the given record.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="timeout"></param>
        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            if (telemetryClient.IsEnabled())
            {
                TrackRecord(record);
            }
        }

        /// <summary>
        /// Submits the given event telemetry.
        /// </summary>
        /// <param name="telemetry"></param>
        void TrackTelemetry(ITelemetry telemetry)
        {
            if (telemetry == null)
                throw new ArgumentNullException(nameof(telemetry));

            // reference parent operation
            if (parentOperationId != null)
                telemetry.Context.Operation.ParentId = parentOperationId;

            // submit to telemetry client
            if (telemetry is TraceTelemetry)
                telemetryClient.TrackTrace((TraceTelemetry)telemetry);
            if (telemetry is EventTelemetry)
                telemetryClient.TrackEvent((EventTelemetry)telemetry);
            if (telemetry is ExceptionTelemetry)
                telemetryClient.TrackException((ExceptionTelemetry)telemetry);
            if (telemetry is RequestTelemetry)
                telemetryClient.TrackRequest((RequestTelemetry)telemetry);
            if (telemetry is MetricTelemetry)
                telemetryClient.TrackMetric((MetricTelemetry)telemetry);
        }

        #region Serialization

        /// <summary>
        /// Serializes the given dictionary for output.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string PrepareDictionary(IDictionary<string, object> data)
        {
            var builder = new StringBuilder();

            using (var writer = XmlWriter.Create(builder, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            {
                writer.WriteStartElement(ITEMS_ELEMENT);

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        writer.WriteStartElement(ITEM_ELEMENT);
                        writer.WriteAttributeString(NAME_ATTRIBUTE, item.Key);

                        if (item.Value == null)
                        {
                            writer.WriteAttributeString(TYPE_ATTRIBUTE, string.Empty);
                            writer.WriteValue(string.Empty);
                        }
                        else
                        {
                            var valueType = item.Value.GetType();
                            writer.WriteAttributeString(TYPE_ATTRIBUTE, valueType.FullName);

                            if (valueType == typeof(int) ||
                                valueType == typeof(float) ||
                                valueType == typeof(double) ||
                                valueType == typeof(long) ||
                                valueType == typeof(bool) ||
                                valueType == typeof(uint) ||
                                valueType == typeof(ushort) ||
                                valueType == typeof(short) ||
                                valueType == typeof(ulong) ||
                                valueType == typeof(string) ||
                                valueType == typeof(DateTimeOffset))
                            {
                                writer.WriteValue(item.Value);
                            }
                            else if (valueType == typeof(Guid))
                            {
                                writer.WriteValue(item.Value.ToString());
                            }
                            else if (valueType == typeof(DateTime))
                            {
                                writer.WriteValue(((DateTime)item.Value).ToUniversalTime());
                            }
                            else
                            {
                                try
                                {
                                    variableSerializer.WriteObject(writer, item.Value);
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }

                        writer.WriteEndElement();
                    }
                }

                writer.WriteEndElement();
                writer.Flush();
            }

            return builder.ToString();
        }

        /// <summary>
        /// Serializes the given annotations for output.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static string PrepareAnnotations(IDictionary<string, string> data)
        {
            return new XElement(ITEMS_ELEMENT,
                    data?.Select(i =>
                        new XElement(ITEM_ELEMENT,
                            new XAttribute(NAME_ATTRIBUTE, i.Key),
                            i.Value)))
                .ToString();
        }

        #endregion

    }

}
