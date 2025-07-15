using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppCRM.Infrastructure.Settings
{
    public class WhatsAppSettings
    {
        public string PhoneNumberId { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string ApiVersion { get; set; } = "v18.0";
    }
}
