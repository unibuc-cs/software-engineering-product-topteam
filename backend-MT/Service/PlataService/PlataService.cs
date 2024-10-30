using backend_MT.Models;
using backend_MT.Repositories.PlataRepository;

namespace backend_MT.Service.PlataService
{
    public class PlataService : IPlataService
    {
        private readonly IPlataRepository _plataRepository;

        public PlataService(IPlataRepository plataRepository)
        {
            _plataRepository = plataRepository;
        }

        public async Task<IEnumerable<Plata>> GetAllPaymentsAsync()
        {
            return await _plataRepository.GetAllPaymentsAsync();
        }

        public async Task<Plata> GetPaymentByIdAsync(int id)
        {
            return await _plataRepository.GetPaymentByIdAsync(id);
        }

        public async Task AddPaymentAsync(Plata plata)
        {
            await _plataRepository.AddPaymentAsync(plata);
        }

        public async Task UpdatePaymentAsync(Plata plata)
        {
            await _plataRepository.UpdatePaymentAsync(plata);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _plataRepository.DeletePaymentAsync(id);
        }
    }
}
