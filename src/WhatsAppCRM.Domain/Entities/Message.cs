namespace WhatsAppCRM.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

        public string Direction { get; set; } = "Outbound"; // "Outbound" or "Inbound"
        public string TextContent { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public string? WhatsAppMessageId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? SeenAt { get; set; }

    }
}