using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.RaspunsTemaRepository
{
    public class RaspunsTemaRepository : IRaspunsTemaRepository
    {
        private readonly ApplicationDbContext _context;

        public RaspunsTemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RaspunsTema>> GetAllResponsesAsync()
        {
            return await _context.raspunsTema.ToListAsync();
        }

        public async Task<RaspunsTema> GetResponseByIdAsync(int id)
        {
            return await _context.raspunsTema.FindAsync(id);
        }

        public async Task AddResponseAsync(RaspunsTema raspunsTema)
        {
            await _context.raspunsTema.AddAsync(raspunsTema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResponseAsync(RaspunsTema raspunsTema)
        {
            _context.raspunsTema.Update(raspunsTema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResponseAsync(int id)
        {
            var raspunsTema = await _context.raspunsTema.FindAsync(id);
            if (raspunsTema != null)
            {
                _context.raspunsTema.Remove(raspunsTema);
                await _context.SaveChangesAsync();
            }
        }
    }
}