using backend_MT.Models;
using backend_MT.Repositories.AbonamentRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.AbonamentService
{
    public class AbonamentService : IAbonamentService
    {
        private readonly IAbonamentRepository _abonamentRepository;

        public AbonamentService(IAbonamentRepository abonamentRepository)
        {
            _abonamentRepository = abonamentRepository;
        }

        public async Task<IEnumerable<Abonament>> GetAllSubscriptionsAsync()
        {
            return await _abonamentRepository.GetAllSubscriptionsAsync();
        }

        public async Task<Abonament> GetSubscriptionByIdAsync(int id)
        {
            return await _abonamentRepository.GetSubscriptionByIdAsync(id);
        }

        public async Task AddSubscriptionAsync(Abonament abonament)
        {
            await _abonamentRepository.AddSubscriptionAsync(abonament);
        }

        public async Task UpdateSubscriptionAsync(Abonament abonament)
        {
            await _abonamentRepository.UpdateSubscriptionAsync(abonament);
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            await _abonamentRepository.DeleteSubscriptionAsync(id);
        }
    }
}