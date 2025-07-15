using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppCRM.Application.DTOs
{
    public class SendMessageRequestDto
    {
        public string ToPhone { get; set; } = string.Empty;
        public string TextBody { get; set; } = string.Empty;
    }
}
