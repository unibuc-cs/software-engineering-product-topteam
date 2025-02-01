using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.MaterialeRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.MaterialeService
{
	public class MaterialService : IMaterialService
	{
		private readonly IMaterialRepository _materialRepository;
		private readonly IMapper _mapper;

		public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
		{
			_materialRepository = materialRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<MaterialDTO>> GetAllMaterialsAsync()
		{
			var materials = await _materialRepository.GetAllMaterialsAsync();
			return _mapper.Map<IEnumerable<MaterialDTO>>(materials);
		}

		public async Task<Material> GetMaterialByIdAsync(int id)
		{
			return await _materialRepository.GetMaterialByIdAsync(id);
		}

		public async Task<bool> AddMaterialAsync(MaterialDTO materialDto)
		{
			var material = _mapper.Map<Material>(materialDto);
			return await _materialRepository.AddMaterialAsync(material);
		}

		public async Task UpdateMaterialAsync(int id, MaterialDTO materialDto)
		{
			var material = await _materialRepository.GetMaterialByIdAsync(id);
			_mapper.Map(materialDto, material);
			await _materialRepository.UpdateMaterialAsync(material);
		}

		public async Task DeleteMaterialAsync(int id)
		{
			await _materialRepository.DeleteMaterialAsync(id);
		}
	}
}
