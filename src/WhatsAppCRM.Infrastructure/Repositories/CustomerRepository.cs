using Microsoft.EntityFrameworkCore;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Infrastructure.Data;

namespace WhatsAppCRM.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CrmDbContext _db;
        public CustomerRepository(CrmDbContext db) => _db = db;

        public async Task<List<Customer>> GetAllAsync() => await _db.Customers.ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id) => await _db.Customers.Include(c => c.Messages).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Customer?> GetByPhoneAsync(string phone) => await _db.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phone);

        public async Task AddAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }
        }
    }
}