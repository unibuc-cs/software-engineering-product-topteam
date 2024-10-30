using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.ElevRepository
{
    public interface IElevRepository
    {
        Task<IEnumerable<Elev>> GetAllStudentsAsync();
        Task<Elev> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Elev elev);
        Task UpdateStudentAsync(Elev elev);
        Task DeleteStudentAsync(string id);
    }
}