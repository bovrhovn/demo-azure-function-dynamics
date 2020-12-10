using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Functions.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Attribute
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public object Value { get; set; }
    }

    public class FormattedValue
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public object Value { get; set; }
    }

    public class Value
    {
        [JsonPropertyName("__type")] public string Type { get; set; }

        [JsonPropertyName("Attributes")] public List<Attribute> Attributes { get; set; }

        [JsonPropertyName("EntityState")] public object EntityState { get; set; }

        [JsonPropertyName("FormattedValues")] public List<FormattedValue> FormattedValues { get; set; }

        [JsonPropertyName("Id")] public string Id { get; set; }

        [JsonPropertyName("KeyAttributes")] public List<object> KeyAttributes { get; set; }

        [JsonPropertyName("LogicalName")] public string LogicalName { get; set; }

        [JsonPropertyName("RelatedEntities")] public List<object> RelatedEntities { get; set; }

        [JsonPropertyName("RowVersion")] public object RowVersion { get; set; }
    }

    public class InputParameter
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public Value Value { get; set; }
    }

    public class OutputParameter
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public class OwningExtension
    {
        [JsonPropertyName("Id")] public string Id { get; set; }

        [JsonPropertyName("KeyAttributes")] public List<object> KeyAttributes { get; set; }

        [JsonPropertyName("LogicalName")] public string LogicalName { get; set; }

        [JsonPropertyName("Name")] public string Name { get; set; }

        [JsonPropertyName("RowVersion")] public object RowVersion { get; set; }
    }

    public class InputParameter2
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public object Value { get; set; }
    }

    public class OwningExtension2
    {
        [JsonPropertyName("Id")] public string Id { get; set; }

        [JsonPropertyName("KeyAttributes")] public List<object> KeyAttributes { get; set; }

        [JsonPropertyName("LogicalName")] public string LogicalName { get; set; }

        [JsonPropertyName("Name")] public string Name { get; set; }

        [JsonPropertyName("RowVersion")] public object RowVersion { get; set; }
    }

    public class SharedVariable
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public object Value { get; set; }
    }

    public class ParentContext
    {
        [JsonPropertyName("BusinessUnitId")] public string BusinessUnitId { get; set; }

        [JsonPropertyName("CorrelationId")] public string CorrelationId { get; set; }

        [JsonPropertyName("Depth")] public int Depth { get; set; }

        [JsonPropertyName("InitiatingUserAzureActiveDirectoryObjectId")]
        public string InitiatingUserAzureActiveDirectoryObjectId { get; set; }

        [JsonPropertyName("InitiatingUserId")] public string InitiatingUserId { get; set; }

        [JsonPropertyName("InputParameters")] public List<InputParameter2> InputParameters { get; set; }

        [JsonPropertyName("IsExecutingOffline")]
        public bool IsExecutingOffline { get; set; }

        [JsonPropertyName("IsInTransaction")] public bool IsInTransaction { get; set; }

        [JsonPropertyName("IsOfflinePlayback")]
        public bool IsOfflinePlayback { get; set; }

        [JsonPropertyName("IsolationMode")] public int IsolationMode { get; set; }

        [JsonPropertyName("MessageName")] public string MessageName { get; set; }

        [JsonPropertyName("Mode")] public int Mode { get; set; }

        [JsonPropertyName("OperationCreatedOn")]
        public DateTime OperationCreatedOn { get; set; }

        [JsonPropertyName("OperationId")] public string OperationId { get; set; }

        [JsonPropertyName("OrganizationId")] public string OrganizationId { get; set; }

        [JsonPropertyName("OrganizationName")] public string OrganizationName { get; set; }

        [JsonPropertyName("OutputParameters")] public List<object> OutputParameters { get; set; }

        [JsonPropertyName("OwningExtension")] public OwningExtension2 OwningExtension { get; set; }

        [JsonPropertyName("ParentContext")] public object Root { get; set; }

        [JsonPropertyName("PostEntityImages")] public List<object> PostEntityImages { get; set; }

        [JsonPropertyName("PreEntityImages")] public List<object> PreEntityImages { get; set; }

        [JsonPropertyName("PrimaryEntityId")] public string PrimaryEntityId { get; set; }

        [JsonPropertyName("PrimaryEntityName")]
        public string PrimaryEntityName { get; set; }

        [JsonPropertyName("RequestId")] public string RequestId { get; set; }

        [JsonPropertyName("SecondaryEntityName")]
        public string SecondaryEntityName { get; set; }

        [JsonPropertyName("SharedVariables")] public List<SharedVariable> SharedVariables { get; set; }

        [JsonPropertyName("Stage")] public int Stage { get; set; }

        [JsonPropertyName("UserAzureActiveDirectoryObjectId")]
        public string UserAzureActiveDirectoryObjectId { get; set; }

        [JsonPropertyName("UserId")] public string UserId { get; set; }
    }

    public class SharedVariable2
    {
        [JsonPropertyName("key")] public string Key { get; set; }

        [JsonPropertyName("value")] public bool Value { get; set; }
    }

    public class WebhookResponse
    {
        [JsonPropertyName("BusinessUnitId")] public string BusinessUnitId { get; set; }

        [JsonPropertyName("CorrelationId")] public string CorrelationId { get; set; }

        [JsonPropertyName("Depth")] public int Depth { get; set; }

        [JsonPropertyName("InitiatingUserAzureActiveDirectoryObjectId")]
        public string InitiatingUserAzureActiveDirectoryObjectId { get; set; }

        [JsonPropertyName("InitiatingUserId")] public string InitiatingUserId { get; set; }

        [JsonPropertyName("InputParameters")] public List<InputParameter> InputParameters { get; set; }

        [JsonPropertyName("IsExecutingOffline")]
        public bool IsExecutingOffline { get; set; }

        [JsonPropertyName("IsInTransaction")] public bool IsInTransaction { get; set; }

        [JsonPropertyName("IsOfflinePlayback")]
        public bool IsOfflinePlayback { get; set; }

        [JsonPropertyName("IsolationMode")] public int IsolationMode { get; set; }

        [JsonPropertyName("MessageName")] public string MessageName { get; set; }

        [JsonPropertyName("Mode")] public int Mode { get; set; }

        [JsonPropertyName("OperationCreatedOn")]
        public DateTime OperationCreatedOn { get; set; }

        [JsonPropertyName("OperationId")] public string OperationId { get; set; }

        [JsonPropertyName("OrganizationId")] public string OrganizationId { get; set; }

        [JsonPropertyName("OrganizationName")] public string OrganizationName { get; set; }

        [JsonPropertyName("OutputParameters")] public List<OutputParameter> OutputParameters { get; set; }

        [JsonPropertyName("OwningExtension")] public OwningExtension OwningExtension { get; set; }

        [JsonPropertyName("ParentContext")] public ParentContext ParentContext { get; set; }

        [JsonPropertyName("PostEntityImages")] public List<object> PostEntityImages { get; set; }

        [JsonPropertyName("PreEntityImages")] public List<object> PreEntityImages { get; set; }

        [JsonPropertyName("PrimaryEntityId")] public string PrimaryEntityId { get; set; }

        [JsonPropertyName("PrimaryEntityName")]
        public string PrimaryEntityName { get; set; }

        [JsonPropertyName("RequestId")] public string RequestId { get; set; }

        [JsonPropertyName("SecondaryEntityName")]
        public string SecondaryEntityName { get; set; }

        [JsonPropertyName("SharedVariables")] public List<SharedVariable2> SharedVariables { get; set; }

        [JsonPropertyName("Stage")] public int Stage { get; set; }

        [JsonPropertyName("UserAzureActiveDirectoryObjectId")]
        public string UserAzureActiveDirectoryObjectId { get; set; }

        [JsonPropertyName("UserId")] public string UserId { get; set; }
    }
}