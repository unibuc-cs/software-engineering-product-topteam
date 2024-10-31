//using backend_MT.Data;
//using backend_MT.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace backend_MT.Repositories.ElevRepository
//{
//    public class ElevRepository : IElevRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public ElevRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<User>> GetAllStudentsAsync()
//        {
//            return await _context.Elevi.ToListAsync();
//        }

//        public async Task<User> GetStudentByIdAsync(string id)
//        {
//            return await _context.Elevi.FindAsync(id);
//        }

//        public async Task AddStudentAsync(User elev)
//        {
//            await _context.Elevi.AddAsync(elev);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateStudentAsync(User elev)
//        {
//            _context.Elevi.Update(elev);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteStudentAsync(string id)
//        {
//            var elev = await _context.Elevi.FindAsync(id);
//            if (elev != null)
//            {
//                _context.Elevi.Remove(elev);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}