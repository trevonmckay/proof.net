using System.Text.Json.Serialization;

namespace Proof.NET
{
    public class AddDocumentRequest
    {
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("resource")]
        public string? Resource { get; set; }

        [JsonPropertyName("document")]
        public string? Document { get; set; }

        [JsonPropertyName("requirement")]
        public DocumentRequirement? Requirement { get; set; }

        [JsonPropertyName("notarization_required")]
        public bool? NotarizationRequired { get; set; }

        [JsonPropertyName("witness_required")]
        public bool? WitnessRequired { get; set; }

        [JsonPropertyName("bundle_position")]
        public int? BundlePosition { get; set; }

        [JsonPropertyName("esign_required")]
        public bool? ESignRequired { get; set; }

        [JsonPropertyName("identity_confirmation_required")]
        public bool? IdentityConfirmationRequired { get; set; }

        [JsonPropertyName("signing_requires_meeting")]
        public bool? SigningRequiresMeeting { get; set; }

        [JsonPropertyName("vaulted")]
        public bool? Vaulted { get; set; }

        [JsonPropertyName("authorization_header")]
        public string? AuthorizationHeader { get; set; }

        [JsonPropertyName("customer_can_annotate")]
        public bool? CustomerCanAnnotate { get; set; }

        [JsonPropertyName("pdf_bookmarked")]
        public bool? PdfBookmarked { get; set; }

        [JsonPropertyName("tracking_id")]
        public string? TrackingId { get; set; }

        [JsonPropertyName("text_tag_syntax")]
        public string? TextTagSyntax { get; set; }
    }
}
