using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Application.Interfaces
{
    public interface ISettingRepository
    {
        Task<string?> GetValueAsync(string key);
        Task SetValueAsync(string key, string value);
    }
}