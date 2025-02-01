using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.RaspunsTemaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.RaspunsTemaService
{
	public class RaspunsTemaService : IRaspunsTemaService
	{
		private readonly IRaspunsTemaRepository _raspunsTemaRepository;
		private readonly IMapper _mapper;

		public RaspunsTemaService(IRaspunsTemaRepository raspunsTemaRepository, IMapper mapper)
		{
			_raspunsTemaRepository = raspunsTemaRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<RaspunsTemaDTO>> GetAllResponsesAsync()
		{
			var responses = await _raspunsTemaRepository.GetAllResponsesAsync();
			return _mapper.Map<IEnumerable<RaspunsTemaDTO>>(responses);
		}

		public async Task<RaspunsTema> GetResponseByIdAsync(int id)
		{
			return await _raspunsTemaRepository.GetResponseByIdAsync(id);
		}

		public async Task<bool> AddResponseAsync(RaspunsTemaDTO raspunsTemaDto)
		{
			var raspunsTema = _mapper.Map<RaspunsTema>(raspunsTemaDto);
			return await _raspunsTemaRepository.AddResponseAsync(raspunsTema);
		}

		public async Task UpdateResponseAsync(int id, RaspunsTemaDTO raspunsTemaDto)
		{
			var raspunsTema = await _raspunsTemaRepository.GetResponseByIdAsync(id);
			_mapper.Map(raspunsTemaDto, raspunsTema);
			await _raspunsTemaRepository.UpdateResponseAsync(raspunsTema);
		}

		public async Task DeleteResponseAsync(int id)
		{
			await _raspunsTemaRepository.DeleteResponseAsync(id);
		}
	}
}
