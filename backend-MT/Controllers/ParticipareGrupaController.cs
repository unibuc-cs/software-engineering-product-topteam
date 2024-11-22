using backend_MT.Models;
using backend_MT.Service.ParticipareGrupaService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipareGrupaController : ControllerBase
    {
        private readonly IParticipareGrupaService _participareGrupaService;

        public ParticipareGrupaController(IParticipareGrupaService participareGrupaService)
        {
            _participareGrupaService = participareGrupaService;
        }

        // GET: api/participaregrupa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipareGrupa>>> GetAllParticipari()
        {
            var participari = await _participareGrupaService.GetAllParticipariAsync();
            return Ok(participari);
        }

        // GET: api/participaregrupa/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipareGrupa>> GetParticipareById(int id)
        {
            var participare = await _participareGrupaService.GetParticipareByIdAsync(id);
            if (participare == null)
            {
                return NotFound();
            }
            return Ok(participare);
        }

        // POST: api/participaregrupa
        [HttpPost]
        public async Task<ActionResult<ParticipareGrupa>> AddParticipare(ParticipareGrupa participare)
        {
            await _participareGrupaService.AddParticipareAsync(participare);
            return CreatedAtAction(nameof(GetParticipareById), new { id = participare.participareGrupaId }, participare);
        }

        // PUT: api/participaregrupa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipare(int id, ParticipareGrupa participare)
        {
            if (id != participare.participareGrupaId)
            {
                return BadRequest();
            }

            await _participareGrupaService.UpdateParticipareAsync(participare);
            return NoContent();
        }

        // DELETE: api/participaregrupa/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipare(int id)
        {
            var participare = await _participareGrupaService.GetParticipareByIdAsync(id);
            if (participare == null)
            {
                return NotFound();
            }

            await _participareGrupaService.DeleteParticipareAsync(id);
            return NoContent();
        }
    }
}
