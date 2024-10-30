using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.MesajRepository
{
    public class MesajRepository : IMesajRepository
    {
        private readonly ApplicationDbContext _context;

        public MesajRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesaj>> GetAllMessagesAsync()
        {
            return await _context.Mesaje.ToListAsync();
        }

        public async Task<Mesaj> GetMessageByIdAsync(int id)
        {
            return await _context.Mesaje.FindAsync(id);
        }

        public async Task AddMessageAsync(Mesaj mesaj)
        {
            await _context.Mesaje.AddAsync(mesaj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(Mesaj mesaj)
        {
            _context.Mesaje.Update(mesaj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var mesaj = await _context.Mesaje.FindAsync(id);
            if (mesaj != null)
            {
                _context.Mesaje.Remove(mesaj);
                await _context.SaveChangesAsync();
            }
        }
    }
}