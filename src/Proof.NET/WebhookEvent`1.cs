using System.Text.Json;

namespace Proof.NET
{
    public class WebhookEvent<TEventData>
    {
        public string? Event { get; set; }

        public TEventData? Data { get; set; }

        protected JsonElement Json { get; set; }

        public string GetRawJson()
        {
            return Json.GetRawText();
        }
    }
}
