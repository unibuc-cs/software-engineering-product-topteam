using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.GrupaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.GrupaService
{
	public class GrupaService : IGrupaService
	{
		private readonly IGrupaRepository _grupaRepository;
		private readonly IMapper _mapper;

		public GrupaService(IGrupaRepository grupaRepository, IMapper mapper)
		{
			_grupaRepository = grupaRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Grupa>> GetAllGroupsAsync()
		{
			return await _grupaRepository.GetAllGroupsAsync();
		}

		public async Task<Grupa> GetGroupByIdAsync(int id)
		{
			return await _grupaRepository.GetGroupByIdAsync(id);
		}

		public async Task<Grupa> AddGroupAsync(GrupaDTO grupaDto)
		{
			var grupa = _mapper.Map<Grupa>(grupaDto);
			if (await _grupaRepository.AddGroupAsync(grupa))
				return grupa;
			return null;
		}

		public async Task UpdateGroupAsync(int id, GrupaDTO grupaDto)
		{
			var grupa = await _grupaRepository.GetGroupByIdAsync(id);
			_mapper.Map(grupaDto, grupa);
			await _grupaRepository.UpdateGroupAsync(grupa);
		}

		public async Task DeleteGroupAsync(int id)
		{
			await _grupaRepository.DeleteGroupAsync(id);
		}
	}
}
