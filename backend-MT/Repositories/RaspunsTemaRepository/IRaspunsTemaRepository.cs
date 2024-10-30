using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.RaspunsTemaRepository
{
    public interface IRaspunsTemaRepository
    {
        Task<IEnumerable<RaspunsTema>> GetAllResponsesAsync();
        Task<RaspunsTema> GetResponseByIdAsync(int id);
        Task AddResponseAsync(RaspunsTema raspunsTema);
        Task UpdateResponseAsync(RaspunsTema raspunsTema);
        Task DeleteResponseAsync(int id);
    }
}