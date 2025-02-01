using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.TemaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.TemaService
{
	public class TemaService : ITemaService
	{
		private readonly ITemaRepository _temaRepository;
		private readonly IMapper _mapper;

		public TemaService(ITemaRepository temaRepository, IMapper mapper)
		{
			_temaRepository = temaRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<TemaDTO>> GetAllAssignmentsAsync()
		{
			var assignments = await _temaRepository.GetAllAssignmentsAsync();
			return _mapper.Map<IEnumerable<TemaDTO>>(assignments);
		}

		public async Task<Tema> GetAssignmentByIdAsync(int id)
		{
			return await _temaRepository.GetAssignmentByIdAsync(id);
		}

		public async Task<bool> AddAssignmentAsync(TemaDTO temaDto)
		{
			var tema = _mapper.Map<Tema>(temaDto);
			return await _temaRepository.AddAssignmentAsync(tema);
		}

		public async Task UpdateAssignmentAsync(int id, TemaDTO temaDto)
		{
			var tema = await _temaRepository.GetAssignmentByIdAsync(id);
			_mapper.Map(temaDto, tema);
			await _temaRepository.UpdateAssignmentAsync(tema);
		}

		public async Task DeleteAssignmentAsync(int id)
		{
			await _temaRepository.DeleteAssignmentAsync(id);
		}
	}
}
