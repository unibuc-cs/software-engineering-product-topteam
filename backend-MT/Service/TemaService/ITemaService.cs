using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.TemaService
{
    public interface ITemaService
    {
        Task<IEnumerable<TemaDTO>> GetAllAssignmentsAsync();
        Task<Tema> GetAssignmentByIdAsync(int id);
        Task<bool> AddAssignmentAsync(TemaDTO tema);
        Task UpdateAssignmentAsync(int id, TemaDTO tema);
        Task DeleteAssignmentAsync(int id);
    }
}
