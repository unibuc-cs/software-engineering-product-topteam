using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.TemaRepository
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Tema>> GetAllAssignmentsAsync();
        Task<Tema> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(Tema tema);
        Task UpdateAssignmentAsync(Tema tema);
        Task DeleteAssignmentAsync(int id);
    }
}