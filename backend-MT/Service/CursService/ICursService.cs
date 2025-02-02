using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.CursService
{
    public interface ICursService
    {
        Task<IEnumerable<Curs>> GetAllCoursesAsync();
        Task<Curs> GetCourseByIdAsync(int id);
        Task<Curs> AddCourseAsync(CursDTO curs);
        Task UpdateCourseAsync(int id, CursDTO curs);
        Task DeleteCourseAsync(int id);
    }
}
