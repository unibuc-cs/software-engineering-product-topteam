using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.CursRepository
{
    public class CursRepository : ICursRepository
    {
        private readonly ApplicationDbContext _context;

        public CursRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curs>> GetAllCoursesAsync()
        {
            return await _context.curs.ToListAsync();
        }

        public async Task<Curs> GetCourseByIdAsync(int id)
        {
            return await _context.curs.FindAsync(id);
        }

        public async Task<bool> AddCourseAsync(Curs curs)
        {
            await _context.curs.AddAsync(curs);
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task UpdateCourseAsync(Curs curs)
        {
            _context.curs.Update(curs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var curs = await _context.curs.FindAsync(id);
            if (curs != null)
            {
                _context.curs.Remove(curs);
                await _context.SaveChangesAsync();
            }
        }
    }
}