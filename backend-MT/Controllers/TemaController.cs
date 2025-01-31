using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.TemaRepository;
using backend_MT.Service.TemaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly ITemaService _temaService;

        public TemaController(ITemaService temaService)
        {
			_temaService = temaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TemaDTO>>> GetAllAssignments()
        {
            var assignments = await _temaService.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tema>> GetAssignmentById(int id)
        {
            var assignment = await _temaService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<ActionResult> AddAssignment(TemaDTO tema)
        {
            if (await _temaService.AddAssignmentAsync(tema))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAssignment(int id, TemaDTO tema)
        {
            await _temaService.UpdateAssignmentAsync(id, tema);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            await _temaService.DeleteAssignmentAsync(id);
            return NoContent();
        }
    }
}
