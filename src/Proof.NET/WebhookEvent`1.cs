namespace Proof.NET
{
    public class WebhookEvent<TEventData> : WebhookEvent
    {
        public WebhookEvent(string eventType, TEventData eventData)
            : base(eventType)
        {
            Data = eventData;
        }

        public TEventData Data { get; }
    }
}
