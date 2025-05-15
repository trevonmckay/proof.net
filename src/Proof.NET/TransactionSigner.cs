using System.Text.Json.Serialization;

namespace Proof.NET
{
    public class TransactionSigner
    {
        public uint? Order { get; set; }

        public string? Email { get; set; }

        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("external_id")]
        public string? ExternalId { get; set; }

        public string? Entity { get; set; }

        public string? Capacity { get; set; }

        public bool? PersonallyKnownToNotary { get; set; }

        [JsonPropertyName("signing_status")]
        public string? SigningStatus { get; set; }

        [JsonPropertyName("link_expired")]
        public bool? LinkExpired { get; set; }

        public string? TransactionAccessLink { get; set; }
    }
}
