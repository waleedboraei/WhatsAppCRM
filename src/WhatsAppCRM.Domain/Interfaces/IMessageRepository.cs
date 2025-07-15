using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAllByCustomerAsync(int customerId);
        Task<Message?> GetByIdAsync(int id);
        Task AddAsync(Message message);
    }
}