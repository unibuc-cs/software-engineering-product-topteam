//using backend_MT.Models;
//using backend_MT.Service.ProfesorService;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace backend_MT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProfesorController : ControllerBase
//    {
//        private readonly IProfesorService _profesorService;
//        private readonly UserManager<Profesor> _userManager;

//        public ProfesorController(IProfesorService profesorService, UserManager<Profesor> userManager)
//        {
//            _profesorService = profesorService;
//            _userManager = userManager;
//        }

//        // GET: api/profesor
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Profesor>>> GetAllTeachers()
//        {
//            var profesori = await _profesorService.GetAllTeachersAsync();
//            return Ok(profesori);
//        }

//        // GET: api/profesor/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Profesor>> GetTeacherById(int id)
//        {
//            var profesor = await _profesorService.GetTeacherByIdAsync(id);
//            if (profesor == null)
//            {
//                return NotFound();
//            }
//            return Ok(profesor);
//        }

//        // POST: api/profesor
//        [HttpPost]
//        public async Task<ActionResult<Profesor>> AddTeacher(Profesor profesor)
//        {
//            // Create the user using UserManager
//            var result = await _userManager.CreateAsync(profesor);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }
//            return CreatedAtAction(nameof(GetTeacherById), new { id = profesor.Id }, profesor); // Assumes Profesor has an Id property
//        }

//        // PUT: api/profesor/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateTeacher(string id, Profesor profesor)
//        {
//            if (id != profesor.Id) // Check if IDs match
//            {
//                return BadRequest();
//            }

//            var existingProfesor = await _userManager.FindByIdAsync(id.ToString());
//            if (existingProfesor == null)
//            {
//                return NotFound();
//            }

//            // Update user properties as needed
//            existingProfesor.Nume = profesor.Nume; // Example property
//            existingProfesor.Email = profesor.Email; // Example property

//            var result = await _userManager.UpdateAsync(existingProfesor);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return NoContent();
//        }

//        // DELETE: api/profesor/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTeacher(int id)
//        {
//            var profesor = await _userManager.FindByIdAsync(id.ToString());
//            if (profesor == null)
//            {
//                return NotFound();
//            }

//            var result = await _userManager.DeleteAsync(profesor);
//            if (!result.Succeeded)
//            {
//                return BadRequest(result.Errors);
//            }

//            return NoContent();
//        }
//    }
//}
