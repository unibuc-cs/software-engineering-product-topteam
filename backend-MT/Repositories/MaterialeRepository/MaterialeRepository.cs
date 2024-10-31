//using backend_MT.Data;
//using backend_MT.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace backend_MT.Repositories.MaterialeRepository
//{
//    public class MaterialRepository : IMaterialRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public MaterialRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Material>> GetAllMaterialsAsync()
//        {
//            return await _context.Materiale.ToListAsync();
//        }

//        public async Task<Material> GetMaterialByIdAsync(int id)
//        {
//            return await _context.Materiale.FindAsync(id);
//        }

//        public async Task AddMaterialAsync(Material material)
//        {
//            await _context.Materiale.AddAsync(material);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateMaterialAsync(Material material)
//        {
//            _context.Materiale.Update(material);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteMaterialAsync(int id)
//        {
//            var material = await _context.Materiale.FindAsync(id);
//            if (material != null)
//            {
//                _context.Materiale.Remove(material);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}