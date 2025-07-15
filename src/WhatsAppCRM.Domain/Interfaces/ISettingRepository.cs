using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Domain.Interfaces
{
    public interface ISettingRepository
    {
        Task<Setting?> GetByKeyAsync(string key);
        Task AddOrUpdateAsync(Setting setting);
    }
}