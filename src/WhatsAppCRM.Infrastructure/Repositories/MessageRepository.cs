using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WhatsAppCRM.Domain.Interfaces;

namespace WhatsAppCRM.Infrastructure.Repositories
{
    public class MessageRepository : Application.Interfaces.IMessageRepository
    {
        private readonly CrmDbContext _db;
        public MessageRepository(CrmDbContext db) => _db = db;

        public async Task<List<Message>> GetByCustomerIdAsync(int customerId)
            => await _db.Messages.Where(m => m.CustomerId == customerId).ToListAsync();

        public async Task AddAsync(Message message)
        {
            _db.Messages.Add(message);
            await _db.SaveChangesAsync();
        }
        public async Task<List<Message>> GetAllAsync()
        {
            return await _db.Messages.ToListAsync();
        }
    }
}