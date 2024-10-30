using backend_MT.Models;
using backend_MT.Repositories.SedintaRepository;

namespace backend_MT.Service.SedintaService
{
    public class SedintaService : ISedintaService
    {
        private readonly ISedintaRepository _sedintaRepository;

        public SedintaService(ISedintaRepository sedintaRepository)
        {
            _sedintaRepository = sedintaRepository;
        }

        public async Task<IEnumerable<Sedinta>> GetAllSessionsAsync()
        {
            return await _sedintaRepository.GetAllSessionsAsync();
        }

        public async Task<Sedinta> GetSessionByIdAsync(int id)
        {
            return await _sedintaRepository.GetSessionByIdAsync(id);
        }

        public async Task AddSessionAsync(Sedinta sedinta)
        {
            await _sedintaRepository.AddSessionAsync(sedinta);
        }

        public async Task UpdateSessionAsync(Sedinta sedinta)
        {
            await _sedintaRepository.UpdateSessionAsync(sedinta);
        }

        public async Task DeleteSessionAsync(int id)
        {
            await _sedintaRepository.DeleteSessionAsync(id);
        }
    }
}
