namespace WhatsAppCRM.Application.Interfaces
{
    public interface IWhatsAppMessagingService
    {
        Task<bool> SendTextMessageAsync(string toPhone, string messageText);
        Task<bool> SendTemplateMessageAsync(string toPhone, string templateName, string languageCode, object[] parameters);
    }
}