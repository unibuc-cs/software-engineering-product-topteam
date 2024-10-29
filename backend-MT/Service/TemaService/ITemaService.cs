using backend_MT.Models;

namespace backend_MT.Service.TemaService
{
    public interface ITemaService
    {
        Task<IEnumerable<Tema>> GetAllAssignmentsAsync();
        Task<Tema> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(Tema tema);
        Task UpdateAssignmentAsync(Tema tema);
        Task DeleteAssignmentAsync(int id);
    }
}
