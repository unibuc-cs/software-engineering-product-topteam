//using backend_MT.Models;
//using backend_MT.Repositories.ProfesorRepository;

//namespace backend_MT.Service.ProfesorService
//{
//    public class ProfesorService : IProfesorService
//    {
//        private readonly IProfesorRepository _profesorRepository;

//        public ProfesorService(IProfesorRepository profesorRepository)
//        {
//            _profesorRepository = profesorRepository;
//        }

//        public async Task<IEnumerable<Profesor>> GetAllTeachersAsync()
//        {
//            return await _profesorRepository.GetAllTeachersAsync();
//        }

//        public async Task<Profesor> GetTeacherByIdAsync(int id)
//        {
//            return await _profesorRepository.GetTeacherByIdAsync(id);
//        }

//        public async Task AddTeacherAsync(Profesor profesor)
//        {
//            await _profesorRepository.AddTeacherAsync(profesor);
//        }

//        public async Task UpdateTeacherAsync(Profesor profesor)
//        {
//            await _profesorRepository.UpdateTeacherAsync(profesor);
//        }

//        public async Task DeleteTeacherAsync(int id)
//        {
//            await _profesorRepository.DeleteTeacherAsync(id);
//        }
//    }
//}
