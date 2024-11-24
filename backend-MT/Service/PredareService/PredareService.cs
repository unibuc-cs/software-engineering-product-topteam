using backend_MT.Models;
using backend_MT.Repositories.PredareRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.PredareService
{
    public class PredareService : IPredareService
    {
        private readonly IPredareRepository _predareRepository;

        public PredareService(IPredareRepository predareRepository)
        {
            _predareRepository = predareRepository;
        }

        public async Task<IEnumerable<Predare>> GetAllPredariAsync()
        {
            return await _predareRepository.GetAllPredariAsync();
        }

        public async Task<Predare> GetPredareByIdAsync(int id)
        {
            return await _predareRepository.GetPredareByIdAsync(id);
        }

        public async Task AddPredareAsync(Predare predare)
        {
            await _predareRepository.AddPredareAsync(predare);
        }

        public async Task UpdatePredareAsync(Predare predare)
        {
            await _predareRepository.UpdatePredareAsync(predare);
        }

        public async Task DeletePredareAsync(int id)
        {
            await _predareRepository.DeletePredareAsync(id);
        }
    }
}