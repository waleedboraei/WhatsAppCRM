using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface ITemplateRepository
    {
        Task<List<Template>> GetAllAsync();
        Task<Template?> GetByIdAsync(int id);
        Task AddAsync(Template template);
        Task UpdateAsync(Template template);
        Task DeleteAsync(int id);
    }
}