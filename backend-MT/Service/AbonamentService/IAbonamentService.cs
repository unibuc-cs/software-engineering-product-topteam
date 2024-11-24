using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.AbonamentService
{
    public interface IAbonamentService
    {
        Task<IEnumerable<Abonament>> GetAllSubscriptionsAsync();
        Task<Abonament> GetSubscriptionByIdAsync(int id);
        Task AddSubscriptionAsync(Abonament abonament);
        Task UpdateSubscriptionAsync(Abonament abonament);
        Task DeleteSubscriptionAsync(int id);
    }
}