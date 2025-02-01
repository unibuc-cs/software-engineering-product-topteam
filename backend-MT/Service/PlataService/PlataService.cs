using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.PlataRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.PlataService
{
	public class PlataService : IPlataService
	{
		private readonly IPlataRepository _plataRepository;
		private readonly IMapper _mapper;

		public PlataService(IPlataRepository plataRepository, IMapper mapper)
		{
			_plataRepository = plataRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<PlataDTO>> GetAllPaymentsAsync()
		{
			var payments = await _plataRepository.GetAllPaymentsAsync();
			return _mapper.Map<IEnumerable<PlataDTO>>(payments);
		}

		public async Task<Plata> GetPaymentByIdAsync(int id)
		{
			return await _plataRepository.GetPaymentByIdAsync(id);
		}

		public async Task<bool> AddPaymentAsync(PlataDTO plataDto)
		{
			var plata = _mapper.Map<Plata>(plataDto);
			return await _plataRepository.AddPaymentAsync(plata);
		}

		public async Task UpdatePaymentAsync(int id, PlataDTO plataDto)
		{
			var plata = await _plataRepository.GetPaymentByIdAsync(id);
			_mapper.Map(plataDto, plata);
			await _plataRepository.UpdatePaymentAsync(plata);
		}

		public async Task DeletePaymentAsync(int id)
		{
			await _plataRepository.DeletePaymentAsync(id);
		}
	}
}
