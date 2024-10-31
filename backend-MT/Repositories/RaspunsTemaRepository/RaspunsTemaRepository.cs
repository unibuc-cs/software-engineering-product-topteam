//using backend_MT.Data;
//using backend_MT.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace backend_MT.Repositories.RaspunsTemaRepository
//{
//    public class RaspunsTemaRepository : IRaspunsTemaRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public RaspunsTemaRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<RaspunsTema>> GetAllResponsesAsync()
//        {
//            return await _context.RaspunsuriTeme.ToListAsync();
//        }

//        public async Task<RaspunsTema> GetResponseByIdAsync(int id)
//        {
//            return await _context.RaspunsuriTeme.FindAsync(id);
//        }

//        public async Task AddResponseAsync(RaspunsTema raspunsTema)
//        {
//            await _context.RaspunsuriTeme.AddAsync(raspunsTema);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateResponseAsync(RaspunsTema raspunsTema)
//        {
//            _context.RaspunsuriTeme.Update(raspunsTema);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteResponseAsync(int id)
//        {
//            var raspunsTema = await _context.RaspunsuriTeme.FindAsync(id);
//            if (raspunsTema != null)
//            {
//                _context.RaspunsuriTeme.Remove(raspunsTema);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}