using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.DisponibilitateRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.DisponibilitateService
{
	public class DisponibilitateService : IDisponibilitateService
	{
		private readonly IDisponibilitateRepository _disponibilitateRepository;
		private readonly IMapper _mapper;

		public DisponibilitateService(IDisponibilitateRepository disponibilitateRepository, IMapper mapper)
		{
			_disponibilitateRepository = disponibilitateRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<DisponibilitateDTO>> GetAllDisponibilitatiAsync()
		{
			var disponibilitati = await _disponibilitateRepository.GetAllDisponibilitatiAsync();
			return _mapper.Map<IEnumerable<DisponibilitateDTO>>(disponibilitati);
		}

		public async Task<Disponibilitate> GetDisponibilitateByIdAsync(int id)
		{
			return await _disponibilitateRepository.GetDisponibilitateByIdAsync(id);
		}

		public async Task<bool> AddDisponibilitateAsync(DisponibilitateDTO disponibilitateDto)
		{
			var disponibilitate = _mapper.Map<Disponibilitate>(disponibilitateDto);
			return await _disponibilitateRepository.AddDisponibilitateAsync(disponibilitate);
		}

		public async Task UpdateDisponibilitateAsync(int id, DisponibilitateDTO disponibilitateDto)
		{
			var disponibilitate = await _disponibilitateRepository.GetDisponibilitateByIdAsync(id);
			_mapper.Map(disponibilitateDto, disponibilitate);
			await _disponibilitateRepository.UpdateDisponibilitateAsync(disponibilitate);
		}

		public async Task DeleteDisponibilitateAsync(int id)
		{
			await _disponibilitateRepository.DeleteDisponibilitateAsync(id);
		}
	}
}
