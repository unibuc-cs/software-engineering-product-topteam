using backend_MT.Models;
using backend_MT.Repositories.TemaRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly ITemaRepository _temaRepository;

        public TemaController(ITemaRepository temaRepository)
        {
            _temaRepository = temaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tema>>> GetAllAssignments()
        {
            var assignments = await _temaRepository.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetAssignmentById(int id)
        {
            var assignment = await _temaRepository.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<ActionResult<Tema>> AddAssignment(Tema tema)
        {
            await _temaRepository.AddAssignmentAsync(tema);
            return CreatedAtAction(nameof(GetAssignmentById), new { id = tema.TemaId }, tema);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAssignment(int id, Tema tema)
        {
            if (id != tema.TemaId)
            {
                return BadRequest();
            }

            await _temaRepository.UpdateAssignmentAsync(tema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            await _temaRepository.DeleteAssignmentAsync(id);
            return NoContent();
        }
    }
}
