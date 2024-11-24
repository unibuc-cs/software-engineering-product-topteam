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
            return await _context.tema.ToListAsync();
        }

        public async Task<Tema> GetAssignmentByIdAsync(int id)
        {
            return await _context.tema.FindAsync(id);
        }

        public async Task AddAssignmentAsync(Tema tema)
        {
            await _context.tema.AddAsync(tema);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Tema tema)
        {
            _context.tema.Update(tema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var tema = await _context.tema.FindAsync(id);
            if (tema != null)
            {
                _context.tema.Remove(tema);
                await _context.SaveChangesAsync();
            }
        }
    }
}