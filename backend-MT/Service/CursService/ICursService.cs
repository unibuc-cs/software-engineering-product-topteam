using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.CursService
{
    public interface ICursService
    {
        Task<IEnumerable<CursDTO>> GetAllCoursesAsync();
        Task<Curs> GetCourseByIdAsync(int id);
        Task<bool> AddCourseAsync(CursDTO curs);
        Task UpdateCourseAsync(int id, CursDTO curs);
        Task DeleteCourseAsync(int id);
    }
}
