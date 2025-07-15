using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface IWhatsAppMessageSender
    {
        Task<string> SendTextMessageAsync(string toPhone, string textBody);
    }
}
