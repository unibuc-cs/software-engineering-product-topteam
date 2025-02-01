using backend_MT.Data;
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
            return await _context.grupa.ToListAsync();
        }

        public async Task<Grupa> GetGroupByIdAsync(int id)
        {
            return await _context.grupa.FindAsync(id);
        }

        public async Task<bool> AddGroupAsync(Grupa grupa)
        {
            await _context.grupa.AddAsync(grupa);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task UpdateGroupAsync(Grupa grupa)
        {
            _context.grupa.Update(grupa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int id)
        {
            var grupa = await _context.grupa.FindAsync(id);
            if (grupa != null)
            {
                _context.grupa.Remove(grupa);
                await _context.SaveChangesAsync();
            }
        }
    }
}