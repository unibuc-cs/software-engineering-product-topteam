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

        public async Task<IEnumerable<CursDTO>> GetAllCoursesAsync()
        {
            return _mapper.Map<IEnumerable<CursDTO>>(await _cursRepository.GetAllCoursesAsync());
        }

        public async Task<Curs> GetCourseByIdAsync(int id)
        {
            return await _cursRepository.GetCourseByIdAsync(id);
        }

        public async Task<bool> AddCourseAsync(CursDTO curs)
        {
            return (await _cursRepository.AddCourseAsync(_mapper.Map<Curs>(curs)));
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
