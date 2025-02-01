using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.SupportRepository
{
    public interface ISupportRepository
    {
        Task<IEnumerable<Support>> GetAllSupportMessagesAsync();
        Task<Support> GetSupportMessageByIdAsync(int id);
        Task<bool> AddSupportMessageAsync(Support support);
        Task UpdateSupportMessageAsync(Support support);
        Task DeleteSupportMessageAsync(int id);
    }
}