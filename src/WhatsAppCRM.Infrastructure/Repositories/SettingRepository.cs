using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WhatsAppCRM.Infrastructure.Repositories
{
    public class SettingRepository : ISettingRepository
    {
        private readonly CrmDbContext _db;
        public SettingRepository(CrmDbContext db) => _db = db;

        public async Task<string?> GetValueAsync(string key)
        {
            var setting = await _db.Settings.FirstOrDefaultAsync(s => s.Key == key);
            return setting?.Value;
        }

        public async Task SetValueAsync(string key, string value)
        {
            var setting = await _db.Settings.FirstOrDefaultAsync(s => s.Key == key);
            if (setting == null)
            {
                _db.Settings.Add(new() { Key = key, Value = value });
            }
            else
            {
                setting.Value = value;
                _db.Settings.Update(setting);
            }
            await _db.SaveChangesAsync();
        }
    }
}