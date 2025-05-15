using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Proof.NET
{
    public class WebhookEvent
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };

        public WebhookEvent(string eventType)
        {
            Event = eventType;
        }

        public string Event { get; }

        protected JsonElement Payload { get; init; }

        public string GetRawJson()
        {
            return Payload.GetRawText();
        }

        private static bool TryCreate<TEventData>(string eventType, JsonElement rootElement, [NotNullWhen(true)] out WebhookEvent? webhookEvent)
        {
            if (rootElement.TryGetProperty("data", out JsonElement dataElement) && dataElement.Deserialize<TEventData>(_jsonSerializerOptions) is TEventData typedData)
            {
                webhookEvent = new WebhookEvent<TEventData>(eventType, typedData)
                {
                    Payload = rootElement,
                };

                return true;
            }

            webhookEvent = null;
            return false;
        }

        private static WebhookEvent Parse(JsonDocument jsonDocument)
        {
            JsonElement rootElement = jsonDocument.RootElement.Clone();
            if (rootElement.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Expected JSON object.");
            }

            if (!rootElement.TryGetProperty("event", out JsonElement eventElement) || eventElement.GetString() is not string eventType)
            {
                throw new JsonException("Missing 'event' property.");
            }

            WebhookEvent? webhookEvent;
            switch (eventType)
            {
                case "transaction.partially_completed" when TryCreate<TransactionPartiallyCompletedEventData>(eventType, rootElement, out webhookEvent):
                    break;
                case "transaction.completed" when TryCreate<TransactionCompletedEventData>(eventType, rootElement, out webhookEvent):
                    break;
                case "transaction.deleted" when TryCreate<TransactionDeletedEventData>(eventType, rootElement, out webhookEvent):
                    break;
                case "transaction.completed_with_rejections" when TryCreate<TransactionCompletedWithRejectionsEventData>(eventType, rootElement, out webhookEvent):
                    break;
                default:
                    webhookEvent = new WebhookEvent(eventType)
                    {
                        Payload = rootElement,
                    };
                    break;
            }

            return webhookEvent;
        }

        public static async Task<WebhookEvent> ParseAsync(Stream jsonContent)
        {
            using JsonDocument jsonDocument = await JsonDocument.ParseAsync(jsonContent);
            return Parse(jsonDocument);
        }

        public static WebhookEvent Parse(string json)
        {
            using JsonDocument jsonDocument = JsonDocument.Parse(json);
            return Parse(jsonDocument);
        }
    }
}
