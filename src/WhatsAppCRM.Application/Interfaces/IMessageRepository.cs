using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetByCustomerIdAsync(int customerId);
        Task AddAsync(Message message);
        Task<List<Message>> GetAllAsync();
    }
}