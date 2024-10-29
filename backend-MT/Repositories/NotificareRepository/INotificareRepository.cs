using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.NotificareRepository
{
    public interface INotificareRepository
    {
        Task<IEnumerable<Notificare>> GetAllNotificationsAsync();
        Task<Notificare> GetNotificationByIdAsync(int id);
        Task AddNotificationAsync(Notificare notificare);
        Task UpdateNotificationAsync(Notificare notificare);
        Task DeleteNotificationAsync(int id);
    }
}