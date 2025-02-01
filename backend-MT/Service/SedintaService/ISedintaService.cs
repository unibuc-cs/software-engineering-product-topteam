using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.SedintaService
{
    public interface ISedintaService
    {
        Task<IEnumerable<SedintaDTO>> GetAllSessionsAsync();
        Task<Sedinta> GetSessionByIdAsync(int id);
        Task<bool> AddSessionAsync(SedintaDTO sedinta);
        Task UpdateSessionAsync(int id, SedintaDTO sedinta);
        Task DeleteSessionAsync(int id);
    }
}
