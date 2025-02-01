using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.PlataService
{
    public interface IPlataService
    {
        Task<IEnumerable<PlataDTO>> GetAllPaymentsAsync();
        Task<Plata> GetPaymentByIdAsync(int id);
        Task<bool> AddPaymentAsync(PlataDTO plata);
        Task UpdatePaymentAsync(int id, PlataDTO plata);
        Task DeletePaymentAsync(int id);
    }
}
