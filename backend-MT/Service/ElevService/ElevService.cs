using backend_MT.Models;
using backend_MT.Repositories.ElevRepository;

namespace backend_MT.Service.ElevService
{
    public class ElevService : IElevService
    {
        private readonly IElevRepository _elevRepository;

        public ElevService(IElevRepository elevRepository)
        {
            _elevRepository = elevRepository;
        }

        public async Task<IEnumerable<User>> GetAllStudentsAsync()
        {
            return await _elevRepository.GetAllStudentsAsync();
        }

        public async Task<User> GetStudentByIdAsync(string id)
        {
            return await _elevRepository.GetStudentByIdAsync(id);
        }

        public async Task AddStudentAsync(User elev)
        {
            await _elevRepository.AddStudentAsync(elev);
        }

        public async Task UpdateStudentAsync(User elev)
        {
            await _elevRepository.UpdateStudentAsync(elev);
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _elevRepository.DeleteStudentAsync(id);
        }
    }
}
