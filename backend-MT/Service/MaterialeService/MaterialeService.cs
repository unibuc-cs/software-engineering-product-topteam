using backend_MT.Models;
using backend_MT.Repositories.MaterialeRepository;

namespace backend_MT.Service.MaterialeService
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _materialRepository.GetAllMaterialsAsync();
        }

        public async Task<Material> GetMaterialByIdAsync(int id)
        {
            return await _materialRepository.GetMaterialByIdAsync(id);
        }

        public async Task AddMaterialAsync(Material material)
        {
            await _materialRepository.AddMaterialAsync(material);
        }

        public async Task UpdateMaterialAsync(Material material)
        {
            await _materialRepository.UpdateMaterialAsync(material);
        }

        public async Task DeleteMaterialAsync(int id)
        {
            await _materialRepository.DeleteMaterialAsync(id);
        }
    }
}
