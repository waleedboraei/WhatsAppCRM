using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Domain.Interfaces;

namespace WhatsAppCRM.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Interfaces.ICustomerRepository _repo;

        public CustomerService(Interfaces.ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _repo.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber
            }).ToList();
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            if (c == null) return null;
            return new CustomerDto { Id = c.Id, Name = c.Name, PhoneNumber = c.PhoneNumber };
        }

        public async Task CreateAsync(CustomerDto dto)
        {
            await _repo.AddAsync(new Customer { Name = dto.Name, PhoneNumber = dto.PhoneNumber });
        }

        public async Task UpdateAsync(CustomerDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null) return;
            entity.Name = dto.Name;
            entity.PhoneNumber = dto.PhoneNumber;
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}