using System.Text.Json.Serialization;

namespace Proof.NET
{
    public class TransactionEventSigner : TransactionSigner
    {
        [JsonPropertyName("signer_id")]
        public string? SignerId { get; set; }
    }
}
