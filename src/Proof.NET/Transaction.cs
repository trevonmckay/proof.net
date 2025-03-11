using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Proof.NET
{
    public sealed class Transaction
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("attachments")]
        public IEnumerable<object>? Attachments { get; set; }

        [JsonPropertyName("cc_recipient_emails")]
        public IEnumerable<string>? CcRecipientEmails { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("date_created")]
        public DateTimeOffset? DateCreated { get; set; }

        [JsonPropertyName("date_updated")]
        public DateTimeOffset? DateUpdated { get; set; }

        [JsonPropertyName("detailed_status")]
        public string? DetailedStatus { get; set; }

        [JsonPropertyName("documents")]
        public IEnumerable<TransactionDocument>? Documents { get; set; }

        [JsonPropertyName("notarization_records")]
        public IEnumerable<object>? NotarizationRecords { get; set; }

        [JsonPropertyName("organization_id")]
        public string? OrganizationId { get; set; }

        [JsonPropertyName("payer")]
        public TransactionPayer? Payer { get; set; }

        [JsonPropertyName("redirect")]
        public TransactionRedirect? Redirect { get; set; }

        [JsonPropertyName("require_secondary_photo_id")]
        public bool? RequireSecondaryPhotoId { get; set; }

        [JsonPropertyName("sender_name")]
        public string? SenderName { get; set; }

        [JsonPropertyName("signer_info")]
        public TransactionSigner? SignerInfo { get; set; }

        [JsonPropertyName("signers")]
        public IEnumerable<TransactionSigner>? Signers { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("transaction_name")]
        public string? TransactionName { get; set; }
    }
}
