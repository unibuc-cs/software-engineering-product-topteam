using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.MaterialeService
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync();
        Task<Material> GetMaterialByIdAsync(int id);
        Task<bool> AddMaterialAsync(MaterialDTO material);
        Task UpdateMaterialAsync(int id, MaterialDTO material);
        Task DeleteMaterialAsync(int id);
    }
}
