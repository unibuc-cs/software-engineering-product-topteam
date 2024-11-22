using backend_MT.Models;
using backend_MT.Repositories.PrezentaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.PrezentaService
{
    public class PrezentaService : IPrezentaService
    {
        private readonly IPrezentaRepository _prezentaRepository;

        public PrezentaService(IPrezentaRepository prezentaRepository)
        {
            _prezentaRepository = prezentaRepository;
        }

        public async Task<IEnumerable<Prezenta>> GetAllPrezenteAsync()
        {
            return await _prezentaRepository.GetAllPrezenteAsync();
        }

        public async Task<Prezenta> GetPrezentaByIdAsync(int id)
        {
            return await _prezentaRepository.GetPrezentaByIdAsync(id);
        }

        public async Task AddPrezentaAsync(Prezenta prezenta)
        {
            await _prezentaRepository.AddPrezentaAsync(prezenta);
        }

        public async Task UpdatePrezentaAsync(Prezenta prezenta)
        {
            await _prezentaRepository.UpdatePrezentaAsync(prezenta);
        }

        public async Task DeletePrezentaAsync(int id)
        {
            await _prezentaRepository.DeletePrezentaAsync(id);
        }
    }
}