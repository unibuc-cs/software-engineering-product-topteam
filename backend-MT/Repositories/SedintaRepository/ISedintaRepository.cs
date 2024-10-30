using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.SedintaRepository
{
    public interface ISedintaRepository
    {
        Task<IEnumerable<Sedinta>> GetAllSessionsAsync();
        Task<Sedinta> GetSessionByIdAsync(int id);
        Task AddSessionAsync(Sedinta sedinta);
        Task UpdateSessionAsync(Sedinta sedinta);
        Task DeleteSessionAsync(int id);
    }
}