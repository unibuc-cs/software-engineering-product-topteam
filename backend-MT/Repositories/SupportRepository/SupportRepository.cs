using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.SupportRepository
{
    public class SupportRepository : ISupportRepository
    {
        private readonly ApplicationDbContext _context;

        public SupportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Support>> GetAllSupportMessagesAsync()
        {
            return await _context.support.ToListAsync();
        }

        public async Task<Support> GetSupportMessageByIdAsync(int id)
        {
            return await _context.support.FindAsync(id);
        }

        public async Task<bool> AddSupportMessageAsync(Support support)
        {
            await _context.support.AddAsync(support);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateSupportMessageAsync(Support support)
        {
            _context.support.Update(support);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupportMessageAsync(int id)
        {
            var support = await _context.support.FindAsync(id);
            if (support != null)
            {
                _context.support.Remove(support);
                await _context.SaveChangesAsync();
            }
        }
    }
}