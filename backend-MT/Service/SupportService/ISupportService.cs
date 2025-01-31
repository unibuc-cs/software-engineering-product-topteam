using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.SupportService
{
    public interface ISupportService
    {
        Task<IEnumerable<SupportDTO>> GetAllSupportMessagesAsync();
        Task<Support> GetSupportMessageByIdAsync(int id);
        Task<bool> AddSupportMessageAsync(SupportDTO support);
        Task UpdateSupportMessageAsync(int id, SupportDTO support);
        Task DeleteSupportMessageAsync(int id);
    }
}
