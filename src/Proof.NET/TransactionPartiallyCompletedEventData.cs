using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Proof.NET
{
    public class TransactionPartiallyCompletedEventData : TransactionEventData
    {
        [JsonPropertyName("date_occurred")]
        public DateTimeOffset? DateOccurred { get; set; }

        [JsonPropertyName("signers")]
        public IEnumerable<TransactionEventSigner>? Signers { get; set; }
    }
}
