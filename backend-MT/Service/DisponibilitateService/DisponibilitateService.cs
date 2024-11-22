using backend_MT.Models;
using backend_MT.Repositories.DisponibilitateRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.DisponibilitateService
{
    public class DisponibilitateService : IDisponibilitateService
    {
        private readonly IDisponibilitateRepository _disponibilitateRepository;

        public DisponibilitateService(IDisponibilitateRepository disponibilitateRepository)
        {
            _disponibilitateRepository = disponibilitateRepository;
        }

        public async Task<IEnumerable<Disponibilitate>> GetAllDisponibilitatiAsync()
        {
            return await _disponibilitateRepository.GetAllDisponibilitatiAsync();
        }

        public async Task<Disponibilitate> GetDisponibilitateByIdAsync(int id)
        {
            return await _disponibilitateRepository.GetDisponibilitateByIdAsync(id);
        }

        public async Task AddDisponibilitateAsync(Disponibilitate disponibilitate)
        {
            await _disponibilitateRepository.AddDisponibilitateAsync(disponibilitate);
        }

        public async Task UpdateDisponibilitateAsync(Disponibilitate disponibilitate)
        {
            await _disponibilitateRepository.UpdateDisponibilitateAsync(disponibilitate);
        }

        public async Task DeleteDisponibilitateAsync(int id)
        {
            await _disponibilitateRepository.DeleteDisponibilitateAsync(id);
        }
    }
}