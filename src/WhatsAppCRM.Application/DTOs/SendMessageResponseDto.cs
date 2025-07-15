using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppCRM.Application.DTOs
{
    public class SendMessageResponseDto
    {
        public bool Success { get; set; }
        public string? WhatsAppMessageId { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
