using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.PlataRepository
{
    public interface IPlataRepository
    {
        Task<IEnumerable<Plata>> GetAllPaymentsAsync();
        Task<Plata> GetPaymentByIdAsync(int id);
        Task<bool> AddPaymentAsync(Plata plata);
        Task UpdatePaymentAsync(Plata plata);
        Task DeletePaymentAsync(int id);
    }
}