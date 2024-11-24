using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.ParticipareGrupaRepository
{
    public class ParticipareGrupaRepository : IParticipareGrupaRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipareGrupaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParticipareGrupa>> GetAllParticipariAsync()
        {
            return await _context.participareGrupa
                .Include(pg => pg.user)
                .Include(pg => pg.grupa)
                .ToListAsync();
        }

        public async Task<ParticipareGrupa> GetParticipareByIdAsync(int id)
        {
            return await _context.participareGrupa
                .Include(pg => pg.user)
                .Include(pg => pg.grupa)
                .FirstOrDefaultAsync(pg => pg.participareGrupaId == id);
        }

        public async Task AddParticipareAsync(ParticipareGrupa participare)
        {
            await _context.participareGrupa.AddAsync(participare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParticipareAsync(ParticipareGrupa participare)
        {
            _context.participareGrupa.Update(participare);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParticipareAsync(int id)
        {
            var participare = await _context.participareGrupa.FindAsync(id);
            if (participare != null)
            {
                _context.participareGrupa.Remove(participare);
                await _context.SaveChangesAsync();
            }
        }
    }
}