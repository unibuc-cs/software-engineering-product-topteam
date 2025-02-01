using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.SedintaRepository
{
    public class SedintaRepository : ISedintaRepository
    {
        private readonly ApplicationDbContext _context;

        public SedintaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sedinta>> GetAllSessionsAsync()
        {
            return await _context.sedinta.ToListAsync();
        }

        public async Task<Sedinta> GetSessionByIdAsync(int id)
        {
            return await _context.sedinta.FindAsync(id);
        }

        public async Task<bool> AddSessionAsync(Sedinta sedinta)
        {
            await _context.sedinta.AddAsync(sedinta);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateSessionAsync(Sedinta sedinta)
        {
            _context.sedinta.Update(sedinta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(int id)
        {
            var sedinta = await _context.sedinta.FindAsync(id);
            if (sedinta != null)
            {
                _context.sedinta.Remove(sedinta);
                await _context.SaveChangesAsync();
            }
        }
    }
}