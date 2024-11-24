using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.NotificareRepository
{
    public class NotificareRepository : INotificareRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificareRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notificare>> GetAllNotificationsAsync()
        {
            return await _context.notificare.ToListAsync();
        }

        public async Task<Notificare> GetNotificationByIdAsync(int id)
        {
            return await _context.notificare.FindAsync(id);
        }

        public async Task AddNotificationAsync(Notificare notificare)
        {
            await _context.notificare.AddAsync(notificare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNotificationAsync(Notificare notificare)
        {
            _context.notificare.Update(notificare);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notificare = await _context.notificare.FindAsync(id);
            if (notificare != null)
            {
                _context.notificare.Remove(notificare);
                await _context.SaveChangesAsync();
            }
        }
    }
}