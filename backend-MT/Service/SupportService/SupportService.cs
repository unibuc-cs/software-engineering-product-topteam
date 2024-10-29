using backend_MT.Models;
using backend_MT.Repositories.SupportRepository;

namespace backend_MT.Service.SupportService
{
    public class SupportService : ISupportService
    {
        private readonly ISupportRepository _supportRepository;

        public SupportService(ISupportRepository supportRepository)
        {
            _supportRepository = supportRepository;
        }

        public async Task<IEnumerable<Support>> GetAllSupportMessagesAsync()
        {
            return await _supportRepository.GetAllSupportMessagesAsync();
        }

        public async Task<Support> GetSupportMessageByIdAsync(int id)
        {
            return await _supportRepository.GetSupportMessageByIdAsync(id);
        }

        public async Task AddSupportMessageAsync(Support support)
        {
            await _supportRepository.AddSupportMessageAsync(support);
        }

        public async Task UpdateSupportMessageAsync(Support support)
        {
            await _supportRepository.UpdateSupportMessageAsync(support);
        }

        public async Task DeleteSupportMessageAsync(int id)
        {
            await _supportRepository.DeleteSupportMessageAsync(id);
        }
    }
}
