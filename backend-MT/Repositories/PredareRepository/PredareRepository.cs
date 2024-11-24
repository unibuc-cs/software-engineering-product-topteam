using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.PredareRepository
{
    public class PredareRepository : IPredareRepository
    {
        private readonly ApplicationDbContext _context;

        public PredareRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Predare>> GetAllPredariAsync()
        {
            return await _context.predare
                .Include(p => p.user)
                .Include(p => p.curs)
                .ToListAsync();
        }

        public async Task<Predare> GetPredareByIdAsync(int id)
        {
            return await _context.predare
                .Include(p => p.user)
                .Include(p => p.curs)
                .FirstOrDefaultAsync(p => p.predareId == id);
        }

        public async Task AddPredareAsync(Predare predare)
        {
            await _context.predare.AddAsync(predare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePredareAsync(Predare predare)
        {
            _context.predare.Update(predare);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePredareAsync(int id)
        {
            var predare = await _context.predare.FindAsync(id);
            if (predare != null)
            {
                _context.predare.Remove(predare);
                await _context.SaveChangesAsync();
            }
        }
    }
}