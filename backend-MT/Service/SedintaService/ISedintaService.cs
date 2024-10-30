using backend_MT.Models;

namespace backend_MT.Service.SedintaService
{
    public interface ISedintaService
    {
        Task<IEnumerable<Sedinta>> GetAllSessionsAsync();
        Task<Sedinta> GetSessionByIdAsync(int id);
        Task AddSessionAsync(Sedinta sedinta);
        Task UpdateSessionAsync(Sedinta sedinta);
        Task DeleteSessionAsync(int id);
    }
}
