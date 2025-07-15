using WhatsAppCRM.Application.DTOs;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task CreateAsync(CustomerDto dto);
        Task UpdateAsync(CustomerDto dto);
        Task DeleteAsync(int id);
    }
}