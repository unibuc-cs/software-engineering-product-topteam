using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.CursRepository
{
    public interface ICursRepository
    {
        Task<IEnumerable<Curs>> GetAllCoursesAsync();
        Task<Curs> GetCourseByIdAsync(int id);
        Task<bool> AddCourseAsync(Curs curs);
        Task UpdateCourseAsync(Curs curs);
        Task DeleteCourseAsync(int id);
    }
}