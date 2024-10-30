using backend_MT.Models;

namespace backend_MT.Service.ElevService
{
    public interface IElevService
    {
        Task<IEnumerable<User>> GetAllStudentsAsync();
        Task<User> GetStudentByIdAsync(string id);
        Task AddStudentAsync(User elev);
        Task UpdateStudentAsync(User elev);
        Task DeleteStudentAsync(string id);
    }
}
