using backend_MT.Models;
using backend_MT.Repositories.GrupaRepository;

namespace backend_MT.Service.GrupaService
{
    public class GrupaService : IGrupaService
    {
        private readonly IGrupaRepository _grupaRepository;

        public GrupaService(IGrupaRepository grupaRepository)
        {
            _grupaRepository = grupaRepository;
        }

        public async Task<IEnumerable<Grupa>> GetAllGroupsAsync()
        {
            return await _grupaRepository.GetAllGroupsAsync();
        }

        public async Task<Grupa> GetGroupByIdAsync(int id)
        {
            return await _grupaRepository.GetGroupByIdAsync(id);
        }

        public async Task AddGroupAsync(Grupa grupa)
        {
            await _grupaRepository.AddGroupAsync(grupa);
        }

        public async Task UpdateGroupAsync(Grupa grupa)
        {
            await _grupaRepository.UpdateGroupAsync(grupa);
        }

        public async Task DeleteGroupAsync(int id)
        {
            await _grupaRepository.DeleteGroupAsync(id);
        }
    }
}
