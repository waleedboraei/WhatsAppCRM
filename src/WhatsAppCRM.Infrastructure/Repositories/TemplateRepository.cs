using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WhatsAppCRM.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly CrmDbContext _db;
        public TemplateRepository(CrmDbContext db) => _db = db;

        public async Task<List<Template>> GetAllAsync() => await _db.Templates.ToListAsync();

        public async Task<Template?> GetByIdAsync(int id) => await _db.Templates.FindAsync(id);

        public async Task AddAsync(Template template)
        {
            _db.Templates.Add(template);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Template template)
        {
            _db.Templates.Update(template);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Templates.FindAsync(id);
            if (entity != null)
            {
                _db.Templates.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}