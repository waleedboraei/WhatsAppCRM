using WhatsAppCRM.Domain.Enums;

namespace WhatsAppCRM.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? WhatsAppMessageId { get; set; }
        public string FromPhone { get; set; }
        public string ToPhone { get; set; }
        public string Content { get; set; }
        public MessageType Type { get; set; }
        public MessageDirection Direction { get; set; }
        public MessageStatus Status { get; set; }
        public DateTime Timestamp { get; set; }

    }
}