using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.NotificareService
{
    public interface INotificareService
    {
        Task<IEnumerable<NotificareDTO>> GetAllNotificationsAsync();
        Task<Notificare> GetNotificationByIdAsync(int id);
        Task<bool> AddNotificationAsync(NotificareDTO notificare);
        Task UpdateNotificationAsync(int id, NotificareDTO notificare);
        Task DeleteNotificationAsync(int id);
    }
}
