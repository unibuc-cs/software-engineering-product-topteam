using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.TemaRepository
{
    public class TemaRepository : ITemaRepository
    {
        private readonly ApplicationDbContext _context;

        public TemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tema>> GetAllAssignmentsAsync()
        {
            return await _context.Teme.ToListAsync();
        }

        public async Task<Tema> GetAssignmentByIdAsync(int id)
        {
            return await _context.Teme.FindAsync(id);
        }

        public async Task AddAssignmentAsync(Tema tema)
        {
            await _context.Teme.AddAsync(tema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Tema tema)
        {
            _context.Teme.Update(tema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var tema = await _context.Teme.FindAsync(id);
            if (tema != null)
            {
                _context.Teme.Remove(tema);
                await _context.SaveChangesAsync();
            }
        }
    }
}