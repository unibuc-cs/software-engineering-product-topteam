//using backend_MT.Data;
//using backend_MT.Models;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace backend_MT.Repositories.ProfesorRepository
//{
//    public class ProfesorRepository : IProfesorRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public ProfesorRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Profesor>> GetAllTeachersAsync()
//        {
//            return await _context.Profesori.ToListAsync();
//        }

//        public async Task<Profesor> GetTeacherByIdAsync(int id)
//        {
//            return await _context.Profesori.FindAsync(id);
//        }

//        public async Task AddTeacherAsync(Profesor profesor)
//        {
//            await _context.Profesori.AddAsync(profesor);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateTeacherAsync(Profesor profesor)
//        {
//            _context.Profesori.Update(profesor);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteTeacherAsync(int id)
//        {
//            var profesor = await _context.Profesori.FindAsync(id);
//            if (profesor != null)
//            {
//                _context.Profesori.Remove(profesor);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
