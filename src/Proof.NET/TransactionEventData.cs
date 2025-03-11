using System.Text.Json.Serialization;

namespace Proof.NET
{
    public abstract class TransactionEventData
    {
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
    }
}
