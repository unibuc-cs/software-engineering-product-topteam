using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.RaspunsTemaService
{
    public interface IRaspunsTemaService
    {
        Task<IEnumerable<RaspunsTemaDTO>> GetAllResponsesAsync();
        Task<RaspunsTema> GetResponseByIdAsync(int id);
        Task<bool> AddResponseAsync(RaspunsTemaDTO raspunsTema);
        Task UpdateResponseAsync(int id, RaspunsTemaDTO raspunsTema);
        Task DeleteResponseAsync(int id);
    }
}
