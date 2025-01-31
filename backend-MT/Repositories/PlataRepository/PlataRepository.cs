using backend_MT.Data;
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
            return await _context.plata.ToListAsync();
        }

        public async Task<Plata> GetPaymentByIdAsync(int id)
        {
            return await _context.plata.FindAsync(id);
        }

        public async Task<bool> AddPaymentAsync(Plata plata)
        {
            await _context.plata.AddAsync(plata);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdatePaymentAsync(Plata plata)
        {
            _context.plata.Update(plata);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaymentAsync(int id)
        {
            var plata = await _context.plata.FindAsync(id);
            if (plata != null)
            {
                _context.plata.Remove(plata);
                await _context.SaveChangesAsync();
            }
        }
    }
}