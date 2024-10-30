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
            return await _context.Support.ToListAsync();
        }

        public async Task<Support> GetSupportMessageByIdAsync(int id)
        {
            return await _context.Support.FindAsync(id);
        }

        public async Task AddSupportMessageAsync(Support support)
        {
            await _context.Support.AddAsync(support);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupportMessageAsync(Support support)
        {
            _context.Support.Update(support);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupportMessageAsync(int id)
        {
            var support = await _context.Support.FindAsync(id);
            if (support != null)
            {
                _context.Support.Remove(support);
                await _context.SaveChangesAsync();
            }
        }
    }
}