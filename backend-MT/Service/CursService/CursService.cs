using backend_MT.Models;
using backend_MT.Repositories.CursRepository;

namespace backend_MT.Service.CursService
{
    public class CursService : ICursService
    {
        private readonly ICursRepository _cursRepository;

        public CursService(ICursRepository cursRepository)
        {
            _cursRepository = cursRepository;
        }

        public async Task<IEnumerable<Curs>> GetAllCoursesAsync()
        {
            return await _cursRepository.GetAllCoursesAsync();
        }

        public async Task<Curs> GetCourseByIdAsync(int id)
        {
            return await _cursRepository.GetCourseByIdAsync(id);
        }

        public async Task AddCourseAsync(Curs curs)
        {
            await _cursRepository.AddCourseAsync(curs);
        }

        public async Task UpdateCourseAsync(Curs curs)
        {
            await _cursRepository.UpdateCourseAsync(curs);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _cursRepository.DeleteCourseAsync(id);
        }
    }
}
