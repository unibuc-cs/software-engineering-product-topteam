using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.CursRepository;

namespace backend_MT.Service.CursService
{
    public class CursService : ICursService
    {
        private readonly ICursRepository _cursRepository;
        private readonly IMapper _mapper;

        public CursService(ICursRepository cursRepository, IMapper mapper)
        {
            _cursRepository = cursRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Curs>> GetAllCoursesAsync()
        {
            return await _cursRepository.GetAllCoursesAsync();
        }

        public async Task<Curs> GetCourseByIdAsync(int id)
        {
            return await _cursRepository.GetCourseByIdAsync(id);
        }

        public async Task<Curs> AddCourseAsync(CursDTO curs)
        {
            var cursToAdd = _mapper.Map<Curs>(curs);
            if (await _cursRepository.AddCourseAsync(cursToAdd))
            {
                return cursToAdd;
            }
            return null;
        }

        public async Task UpdateCourseAsync(int id, CursDTO curs)
        {
            var updatedCurs = await _cursRepository.GetCourseByIdAsync(id);
            _mapper.Map(curs, updatedCurs);
            await _cursRepository.UpdateCourseAsync(updatedCurs);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _cursRepository.DeleteCourseAsync(id);
        }
    }
}
