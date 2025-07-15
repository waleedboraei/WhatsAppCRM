using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByPhoneAsync(string phone);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
    }
}