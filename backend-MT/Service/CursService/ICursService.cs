using backend_MT.Models;

namespace backend_MT.Service.CursService
{
    public interface ICursService
    {
        Task<IEnumerable<Curs>> GetAllCoursesAsync();
        Task<Curs> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Curs curs);
        Task UpdateCourseAsync(Curs curs);
        Task DeleteCourseAsync(int id);
    }
}
