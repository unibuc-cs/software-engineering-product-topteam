using backend_MT.Models;

namespace backend_MT.Service.SupportService
{
    public interface ISupportService
    {
        Task<IEnumerable<Support>> GetAllSupportMessagesAsync();
        Task<Support> GetSupportMessageByIdAsync(int id);
        Task AddSupportMessageAsync(Support support);
        Task UpdateSupportMessageAsync(Support support);
        Task DeleteSupportMessageAsync(int id);
    }
}
