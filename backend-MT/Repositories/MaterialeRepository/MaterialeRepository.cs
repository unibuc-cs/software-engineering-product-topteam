using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.MaterialeRepository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
        {
            return await _context.material.ToListAsync();
        }

        public async Task<Material> GetMaterialByIdAsync(int id)
        {
            return await _context.material.FindAsync(id);
        }

        public async Task<bool> AddMaterialAsync(Material material)
        {
            await _context.material.AddAsync(material);
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task UpdateMaterialAsync(Material material)
        {
            _context.material.Update(material);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMaterialAsync(int id)
        {
            var material = await _context.material.FindAsync(id);
            if (material != null)
            {
                _context.material.Remove(material);
                await _context.SaveChangesAsync();
            }
        }
    }
}