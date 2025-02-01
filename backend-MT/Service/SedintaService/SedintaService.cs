using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.SedintaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.SedintaService
{
	public class SedintaService : ISedintaService
	{
		private readonly ISedintaRepository _sedintaRepository;
		private readonly IMapper _mapper;

		public SedintaService(ISedintaRepository sedintaRepository, IMapper mapper)
		{
			_sedintaRepository = sedintaRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SedintaDTO>> GetAllSessionsAsync()
		{
			var sessions = await _sedintaRepository.GetAllSessionsAsync();
			return _mapper.Map<IEnumerable<SedintaDTO>>(sessions);
		}

		public async Task<Sedinta> GetSessionByIdAsync(int id)
		{
			return await _sedintaRepository.GetSessionByIdAsync(id);
		}

		public async Task<bool> AddSessionAsync(SedintaDTO sedintaDto)
		{
			var sedinta = _mapper.Map<Sedinta>(sedintaDto);
			return await _sedintaRepository.AddSessionAsync(sedinta);
		}

		public async Task UpdateSessionAsync(int id, SedintaDTO sedintaDto)
		{
			var sedinta = await _sedintaRepository.GetSessionByIdAsync(id);
			_mapper.Map(sedintaDto, sedinta);
			await _sedintaRepository.UpdateSessionAsync(sedinta);
		}

		public async Task DeleteSessionAsync(int id)
		{
			await _sedintaRepository.DeleteSessionAsync(id);
		}
	}
}
