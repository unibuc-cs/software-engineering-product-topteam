using backend_MT.Models;

namespace backend_MT.Service.ProfesorService
{
    public interface IProfesorService
    {
        Task<IEnumerable<Profesor>> GetAllTeachersAsync();
        Task<Profesor> GetTeacherByIdAsync(int id);
        Task AddTeacherAsync(Profesor profesor);
        Task UpdateTeacherAsync(Profesor profesor);
        Task DeleteTeacherAsync(int id);
    }
}
