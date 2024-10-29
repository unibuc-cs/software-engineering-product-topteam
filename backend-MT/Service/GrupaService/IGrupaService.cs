using backend_MT.Models;

namespace backend_MT.Service.GrupaService
{
    public interface IGrupaService
    {
        Task<IEnumerable<Grupa>> GetAllGroupsAsync();
        Task<Grupa> GetGroupByIdAsync(int id);
        Task AddGroupAsync(Grupa grupa);
        Task UpdateGroupAsync(Grupa grupa);
        Task DeleteGroupAsync(int id);
    }
}
