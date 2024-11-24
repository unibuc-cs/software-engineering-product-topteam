using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.PrezentaRepository
{
    public class PrezentaRepository : IPrezentaRepository
    {
        private readonly ApplicationDbContext _context;

        public PrezentaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prezenta>> GetAllPrezenteAsync()
        {
            return await _context.prezenta
                .Include(p => p.user)
                .Include(p => p.sedinta)
                .ToListAsync();
        }

        public async Task<Prezenta> GetPrezentaByIdAsync(int id)
        {
            return await _context.prezenta
                .Include(p => p.user)
                .Include(p => p.sedinta)
                .FirstOrDefaultAsync(p => p.prezentaId == id);
        }

        public async Task AddPrezentaAsync(Prezenta prezenta)
        {
            await _context.prezenta.AddAsync(prezenta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrezentaAsync(Prezenta prezenta)
        {
            _context.prezenta.Update(prezenta);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrezentaAsync(int id)
        {
            var prezenta = await _context.prezenta.FindAsync(id);
            if (prezenta != null)
            {
                _context.prezenta.Remove(prezenta);
                await _context.SaveChangesAsync();
            }
        }
    }
}