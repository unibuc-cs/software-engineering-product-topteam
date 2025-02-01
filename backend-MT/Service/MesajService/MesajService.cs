using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.MesajRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.MesajService
{
	public class MesajService : IMesajService
	{
		private readonly IMesajRepository _mesajRepository;
		private readonly IMapper _mapper;

		public MesajService(IMesajRepository mesajRepository, IMapper mapper)
		{
			_mesajRepository = mesajRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<MesajDTO>> GetAllMessagesAsync()
		{
			var messages = await _mesajRepository.GetAllMessagesAsync();
			return _mapper.Map<IEnumerable<MesajDTO>>(messages);
		}

		public async Task<Mesaj> GetMessageByIdAsync(int id)
		{
			return await _mesajRepository.GetMessageByIdAsync(id);
		}

		public async Task<bool> AddMessageAsync(MesajDTO mesajDto)
		{
			var mesaj = _mapper.Map<Mesaj>(mesajDto);
			return await _mesajRepository.AddMessageAsync(mesaj);
		}

		public async Task UpdateMessageAsync(int id, MesajDTO mesajDto)
		{
			var mesaj = await _mesajRepository.GetMessageByIdAsync(id);
			_mapper.Map(mesajDto, mesaj);
			await _mesajRepository.UpdateMessageAsync(mesaj);
		}

		public async Task DeleteMessageAsync(int id)
		{
			await _mesajRepository.DeleteMessageAsync(id);
		}
	}
}
