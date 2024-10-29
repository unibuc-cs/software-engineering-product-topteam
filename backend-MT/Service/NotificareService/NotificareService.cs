using backend_MT.Models;
using backend_MT.Repositories.NotificareRepository;

namespace backend_MT.Service.NotificareService
{
    public class NotificationService : INotificationService
    {
        private readonly INotificareRepository _notificareRepository;

        public NotificationService(INotificareRepository notificareRepository)
        {
            _notificareRepository = notificareRepository;
        }

        public async Task<IEnumerable<Notificare>> GetAllNotificationsAsync()
        {
            return await _notificareRepository.GetAllNotificationsAsync();
        }

        public async Task<Notificare> GetNotificationByIdAsync(int id)
        {
            return await _notificareRepository.GetNotificationByIdAsync(id);
        }

        public async Task AddNotificationAsync(Notificare notificare)
        {
            await _notificareRepository.AddNotificationAsync(notificare);
        }

        public async Task UpdateNotificationAsync(Notificare notificare)
        {
            await _notificareRepository.UpdateNotificationAsync(notificare);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await _notificareRepository.DeleteNotificationAsync(id);
        }
    }
}
