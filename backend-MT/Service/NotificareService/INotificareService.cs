using backend_MT.Models;

namespace backend_MT.Service.NotificareService
{
    public interface INotificationService
    {
        Task<IEnumerable<Notificare>> GetAllNotificationsAsync();
        Task<Notificare> GetNotificationByIdAsync(int id);
        Task AddNotificationAsync(Notificare notificare);
        Task UpdateNotificationAsync(Notificare notificare);
        Task DeleteNotificationAsync(int id);
    }
}
