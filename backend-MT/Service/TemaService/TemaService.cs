using backend_MT.Models;
using backend_MT.Repositories.TemaRepository;

namespace backend_MT.Service.TemaService
{
    public class TemaService : ITemaService
    {
        private readonly ITemaRepository _temaRepository;

        public TemaService(ITemaRepository temaRepository)
        {
            _temaRepository = temaRepository;
        }

        public async Task<IEnumerable<Tema>> GetAllAssignmentsAsync()
        {
            return await _temaRepository.GetAllAssignmentsAsync();
        }

        public async Task<Tema> GetAssignmentByIdAsync(int id)
        {
            return await _temaRepository.GetAssignmentByIdAsync(id);
        }

        public async Task AddAssignmentAsync(Tema tema)
        {
            await _temaRepository.AddAssignmentAsync(tema);
        }

        public async Task UpdateAssignmentAsync(Tema tema)
        {
            await _temaRepository.UpdateAssignmentAsync(tema);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            await _temaRepository.DeleteAssignmentAsync(id);
        }
    }
}
