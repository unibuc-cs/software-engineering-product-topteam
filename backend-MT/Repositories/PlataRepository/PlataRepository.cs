using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.PlataRepository
{
    public class PlataRepository : IPlataRepository
    {
        private readonly ApplicationDbContext _context;

        public PlataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plata>> GetAllPaymentsAsync()
        {
            return await _context.Plati.ToListAsync();
        }

        public async Task<Plata> GetPaymentByIdAsync(int id)
        {
            return await _context.Plati.FindAsync(id);
        }

        public async Task AddPaymentAsync(Plata plata)
        {
            await _context.Plati.AddAsync(plata);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Plata plata)
        {
            _context.Plati.Update(plata);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var plata = await _context.Plati.FindAsync(id);
            if (plata != null)
            {
                _context.Plati.Remove(plata);
                await _context.SaveChangesAsync();
            }
        }
    }
}