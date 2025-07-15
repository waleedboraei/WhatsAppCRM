using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsAppCRM.Application.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LocalTime { get; set; }
        public bool IsOnline { get; set; }
        public bool HasUnreadMessages { get; set; }
    }
}

