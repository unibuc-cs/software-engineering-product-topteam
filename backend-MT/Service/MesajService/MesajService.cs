using backend_MT.Models;
using backend_MT.Repositories.MesajRepository;

namespace backend_MT.Service.MesajService
{
    public class MesajService : IMesajService
    {
        private readonly IMesajRepository _mesajRepository;

        public MesajService(IMesajRepository mesajRepository)
        {
            _mesajRepository = mesajRepository;
        }

        public async Task<IEnumerable<Mesaj>> GetAllMessagesAsync()
        {
            return await _mesajRepository.GetAllMessagesAsync();
        }

        public async Task<Mesaj> GetMessageByIdAsync(int id)
        {
            return await _mesajRepository.GetMessageByIdAsync(id);
        }

        public async Task AddMessageAsync(Mesaj mesaj)
        {
            await _mesajRepository.AddMessageAsync(mesaj);
        }

        public async Task UpdateMessageAsync(Mesaj mesaj)
        {
            await _mesajRepository.UpdateMessageAsync(mesaj);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _mesajRepository.DeleteMessageAsync(id);
        }
    }
}
