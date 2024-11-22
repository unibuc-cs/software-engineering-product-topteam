using backend_MT.Models;
using backend_MT.Service.CursService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursController : ControllerBase
    {
        private readonly ICursService _cursService;

        public CursController(ICursService cursService)
        {
            _cursService = cursService;
        }

        // GET: api/curs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curs>>> GetAllCourses()
        {
            var cursuri = await _cursService.GetAllCoursesAsync();
            return Ok(cursuri);
        }

        // GET: api/curs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curs>> GetCourseById(int id)
        {
            var curs = await _cursService.GetCourseByIdAsync(id);
            if (curs == null)
            {
                return NotFound();
            }
            return Ok(curs);
        }

        // POST: api/curs
        [HttpPost]
        public async Task<ActionResult<Curs>> AddCourse(Curs curs)
        {
            await _cursService.AddCourseAsync(curs);
            return CreatedAtAction(nameof(GetCourseById), new { id = curs.cursId }, curs); // Asumând că Curs are o proprietate Id
        }

        // PUT: api/curs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Curs curs)
        {
            if (id != curs.cursId) // Verifică dacă ID-urile se potrivesc
            {
                return BadRequest();
            }

            await _cursService.UpdateCourseAsync(curs);
            return NoContent();
        }

        // DELETE: api/curs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var curs = await _cursService.GetCourseByIdAsync(id);
            if (curs == null)
            {
                return NotFound();
            }

            await _cursService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}