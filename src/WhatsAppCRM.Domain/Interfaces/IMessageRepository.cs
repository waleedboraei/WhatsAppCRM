using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<Message?> GetByIdAsync(Guid id);
        Task UpdateAsync(Message message);
    }
}