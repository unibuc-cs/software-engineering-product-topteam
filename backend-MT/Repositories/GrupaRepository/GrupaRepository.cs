using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.GrupaRepository
{
    public class GrupaRepository : IGrupaRepository
    {
        private readonly ApplicationDbContext _context;

        public GrupaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grupa>> GetAllGroupsAsync()
        {
            return await _context.Grupe.ToListAsync();
        }

        public async Task<Grupa> GetGroupByIdAsync(int id)
        {
            return await _context.Grupe.FindAsync(id);
        }

        public async Task AddGroupAsync(Grupa grupa)
        {
            await _context.Grupe.AddAsync(grupa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Grupa grupa)
        {
            _context.Grupe.Update(grupa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var grupa = await _context.Grupe.FindAsync(id);
            if (grupa != null)
            {
                _context.Grupe.Remove(grupa);
                await _context.SaveChangesAsync();
            }
        }
    }
}