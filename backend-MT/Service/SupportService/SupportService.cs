using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.SupportRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.SupportService
{
	public class SupportService : ISupportService
	{
		private readonly ISupportRepository _supportRepository;
		private readonly IMapper _mapper;

		public SupportService(ISupportRepository supportRepository, IMapper mapper)
		{
			_supportRepository = supportRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<SupportDTO>> GetAllSupportMessagesAsync()
		{
			var supportMessages = await _supportRepository.GetAllSupportMessagesAsync();
			return _mapper.Map<IEnumerable<SupportDTO>>(supportMessages);
		}

		public async Task<Support> GetSupportMessageByIdAsync(int id)
		{
			return await _supportRepository.GetSupportMessageByIdAsync(id);
		}

		public async Task<bool> AddSupportMessageAsync(SupportDTO supportDto)
		{
			var support = _mapper.Map<Support>(supportDto);
			return await _supportRepository.AddSupportMessageAsync(support);
		}

		public async Task UpdateSupportMessageAsync(int id, SupportDTO supportDto)
		{
			var support = await _supportRepository.GetSupportMessageByIdAsync(id);
			_mapper.Map(supportDto, support);
			await _supportRepository.UpdateSupportMessageAsync(support);
		}

		public async Task DeleteSupportMessageAsync(int id)
		{
			await _supportRepository.DeleteSupportMessageAsync(id);
		}
	}
}
