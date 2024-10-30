using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.GrupaRepository
{
    public interface IGrupaRepository
    {
        Task<IEnumerable<Grupa>> GetAllGroupsAsync();
        Task<Grupa> GetGroupByIdAsync(int id);
        Task AddGroupAsync(Grupa grupa);
        Task UpdateGroupAsync(Grupa grupa);
        Task DeleteGroupAsync(int id);
    }
}