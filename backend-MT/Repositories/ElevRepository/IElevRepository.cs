using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.ElevRepository
{
    public interface IElevRepository
    {
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<User> GetStudentByIdAsync(string id);
        Task AddStudentAsync(User elev);
        Task UpdateStudentAsync(User elev);
        Task DeleteStudentAsync(string id);
    }
}