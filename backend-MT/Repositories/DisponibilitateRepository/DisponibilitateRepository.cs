using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.DisponibilitateRepository
{
    public class DisponibilitateRepository : IDisponibilitateRepository
    {
        private readonly ApplicationDbContext _context;

        public DisponibilitateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disponibilitate>> GetAllDisponibilitatiAsync()
        {
            return await _context.disponibilitate.Include(d => d.user).ToListAsync();
        }

        public async Task<Disponibilitate> GetDisponibilitateByIdAsync(int id)
        {
            return await _context.disponibilitate
                .Include(d => d.user)
                .FirstOrDefaultAsync(d => d.disponibilitateId == id);
        }

        public async Task AddDisponibilitateAsync(Disponibilitate disponibilitate)
        {
            await _context.disponibilitate.AddAsync(disponibilitate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDisponibilitateAsync(Disponibilitate disponibilitate)
        {
            _context.disponibilitate.Update(disponibilitate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDisponibilitateAsync(int id)
        {
            var disponibilitate = await _context.disponibilitate.FindAsync(id);
            if (disponibilitate != null)
            {
                _context.disponibilitate.Remove(disponibilitate);
                await _context.SaveChangesAsync();
            }
        }
    }
}