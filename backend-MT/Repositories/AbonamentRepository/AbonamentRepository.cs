using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.AbonamentRepository
{
    public class AbonamentRepository : IAbonamentRepository
    {
        private readonly ApplicationDbContext _context;

        public AbonamentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Abonament>> GetAllSubscriptionsAsync()
        {
            return await _context.abonament.Include(a => a.user).Include(a => a.curs).ToListAsync();
        }

        public async Task<Abonament> GetSubscriptionByIdAsync(int id)
        {
            return await _context.abonament
                .Include(a => a.user)
                .Include(a => a.curs)
                .FirstOrDefaultAsync(a => a.abonamentId == id);
        }

        public async Task AddSubscriptionAsync(Abonament abonament)
        {
            await _context.abonament.AddAsync(abonament);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionAsync(Abonament abonament)
        {
            _context.abonament.Update(abonament);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubscriptionAsync(int id)
        {
            var abonament = await _context.abonament.FindAsync(id);
            if (abonament != null)
            {
                _context.abonament.Remove(abonament);
                await _context.SaveChangesAsync();
            }
        }
    }
}