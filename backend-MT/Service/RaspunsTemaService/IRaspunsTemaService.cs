using backend_MT.Models;

namespace backend_MT.Service.RaspunsTemaService
{
    public interface IRaspunsTemaService
    {
        Task<IEnumerable<RaspunsTema>> GetAllResponsesAsync();
        Task<RaspunsTema> GetResponseByIdAsync(int id);
        Task AddResponseAsync(RaspunsTema raspunsTema);
        Task UpdateResponseAsync(RaspunsTema raspunsTema);
        Task DeleteResponseAsync(int id);
    }
}
