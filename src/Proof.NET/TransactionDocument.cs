using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Proof.NET
{
    public class TransactionDocument
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("allowed_actions")]
        public IEnumerable<string>? AllowedActions { get; set; }

        [JsonPropertyName("bundle_position")]
        public int? BundlePosition { get; set; }

        [JsonPropertyName("completion_state")]
        public string? CompletionState { get; set; }

        [JsonPropertyName("date_created")]
        public DateTimeOffset? DateCreated { get; set; }

        [JsonPropertyName("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [JsonPropertyName("document_name")]
        public string? DocumentName { get; set; }

        [JsonPropertyName("esign_required")]
        public bool? ESignRequired { get; set; }

        [JsonPropertyName("identity_confirmation_required")]
        public bool? IdentityConfirmationRequired { get; set; }

        [JsonPropertyName("notarization_required")]
        public bool? NotarizationRequired { get; set; }

        [JsonPropertyName("processing_state")]
        public string? ProcessingState { get; set; }

        [JsonPropertyName("requirement")]
        public string? Requirement { get; set; }

        [JsonPropertyName("signing_designation_groups")]
        public IEnumerable<object>? SigningDesignationGroups { get; set; }

        [JsonPropertyName("signing_designations")]
        public IEnumerable<object>? SigningDesignations { get; set; }

        [JsonPropertyName("vaulted")]
        public bool? Vaulted { get; set; }
    }
}
