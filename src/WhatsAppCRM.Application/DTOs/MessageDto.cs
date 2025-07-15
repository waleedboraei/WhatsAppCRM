using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsAppCRM.Application.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string TextContent { get; set; } = string.Empty;
        public string Direction { get; set; } = "Outbound";
        public string PhoneNumber { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? SeenAt { get; set; }
    }
}
