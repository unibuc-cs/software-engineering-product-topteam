using backend_MT.Models;

namespace backend_MT.Service.ElevService
{
    public interface IElevService
    {
        Task<IEnumerable<Elev>> GetAllStudentsAsync();
        Task<Elev> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Elev elev);
        Task UpdateStudentAsync(Elev elev);
        Task DeleteStudentAsync(string id);
    }
}
