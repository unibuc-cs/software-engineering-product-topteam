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
            return await _context.Sedinte.ToListAsync();
        }

        public async Task<Sedinta> GetSessionByIdAsync(int id)
        {
            return await _context.Sedinte.FindAsync(id);
        }

        public async Task AddSessionAsync(Sedinta sedinta)
        {
            await _context.Sedinte.AddAsync(sedinta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSessionAsync(Sedinta sedinta)
        {
            _context.Sedinte.Update(sedinta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(int id)
        {
            var sedinta = await _context.Sedinte.FindAsync(id);
            if (sedinta != null)
            {
                _context.Sedinte.Remove(sedinta);
                await _context.SaveChangesAsync();
            }
        }
    }
}