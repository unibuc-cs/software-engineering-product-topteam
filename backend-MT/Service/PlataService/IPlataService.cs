using backend_MT.Models;

namespace backend_MT.Service.PlataService
{
    public interface IPlataService
    {
        Task<IEnumerable<Plata>> GetAllPaymentsAsync();
        Task<Plata> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Plata plata);
        Task UpdatePaymentAsync(Plata plata);
        Task DeletePaymentAsync(int id);
    }
}
