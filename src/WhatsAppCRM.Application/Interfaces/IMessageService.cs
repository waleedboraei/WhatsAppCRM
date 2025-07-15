using WhatsAppCRM.Application.DTOs;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(MessageDto dto);
        Task<List<MessageDto>> GetAllAsync();
        Task<List<MessageDto>> GetByCustomerIdAsync(int customerId);
        Task SendAsync(MessageDto dto);
    }
}