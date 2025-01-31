using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.GrupaService
{
    public interface IGrupaService
    {
        Task<IEnumerable<GrupaDTO>> GetAllGroupsAsync();
        Task<Grupa> GetGroupByIdAsync(int id);
        Task<bool> AddGroupAsync(GrupaDTO grupa);
        Task UpdateGroupAsync(int id, GrupaDTO grupa);
        Task DeleteGroupAsync(int id);
    }
}
