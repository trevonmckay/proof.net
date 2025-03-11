using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proof.NET
{
    public class WebhookEvent : WebhookEvent<dynamic>
    {
        private static WebhookEvent Parse(JsonDocument jsonDocument)
        {
            JsonElement jsonElement = jsonDocument.RootElement;
            if (jsonElement.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Expected JSON object.");
            }

            if (!jsonElement.TryGetProperty("event", out JsonElement eventElement) || eventElement.GetString() is not string eventType)
            {
                throw new JsonException("Missing 'event' property.");
            }

            JsonElement dataElement = jsonElement.GetProperty("data");

            object? eventData;
            switch (eventType)
            {
                case "transaction.partially_completed":
                    eventData = dataElement.Deserialize<TransactionPartiallyCompletedEventData>();
                    break;
                case "transaction.completed":
                    eventData = dataElement.Deserialize<TransactionCompletedEventData>();
                    break;
                case "transaction.deleted":
                    eventData = dataElement.Deserialize<TransactionDeletedEventData>();
                    break;
                case "transaction.completed_with_rejections":
                    eventData = dataElement.Deserialize<TransactionCompletedWithRejectionsEventData>();
                    break;
                default:
                    eventData = dataElement;
                    break;
            }

            return new WebhookEvent
            {
                Event = eventType,
                Data = eventData,
                Json = jsonElement,
            };
        }

        public static async Task<WebhookEvent> ParseAsync(Stream jsonContent)
        {
            JsonDocument jsonDocument = await JsonDocument.ParseAsync(jsonContent);
            return Parse(jsonDocument);
        }

        public static WebhookEvent Parse(string json)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            return Parse(jsonDocument);
        }
    }
}
