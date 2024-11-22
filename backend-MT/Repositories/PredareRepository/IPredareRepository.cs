using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.PredareRepository
{
    public interface IPredareRepository
    {
        Task<IEnumerable<Predare>> GetAllPredariAsync();
        Task<Predare> GetPredareByIdAsync(int id);
        Task AddPredareAsync(Predare predare);
        Task UpdatePredareAsync(Predare predare);
        Task DeletePredareAsync(int id);
    }
}