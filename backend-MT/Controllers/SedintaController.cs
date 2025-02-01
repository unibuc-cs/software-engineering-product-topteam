using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Service.SedintaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedintaController : ControllerBase
    {
        private readonly ISedintaService _sedintaService;

        public SedintaController(ISedintaService sedintaService)
        {
            _sedintaService = sedintaService;
        }

        // GET: api/sedinta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SedintaDTO>>> GetAllSessions()
        {
            var sedinte = await _sedintaService.GetAllSessionsAsync();
            return Ok(sedinte);
        }

        // GET: api/sedinta/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Sedinta>> GetSessionById(int id)
        {
            var sedinta = await _sedintaService.GetSessionByIdAsync(id);
            if (sedinta == null)
            {
                return NotFound();
            }
            return Ok(sedinta);
        }

        // POST: api/sedinta
        [HttpPost]
        public async Task<ActionResult> AddSession(SedintaDTO sedinta)
        {
            if (await _sedintaService.AddSessionAsync(sedinta))
                return Ok();
            return BadRequest();
        }

        // PUT: api/sedinta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, SedintaDTO sedinta)
        {
            await _sedintaService.UpdateSessionAsync(id, sedinta);
            return NoContent();
        }

        // DELETE: api/sedinta/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var sedinta = await _sedintaService.GetSessionByIdAsync(id);
            if (sedinta == null)
            {
                return NotFound();
            }

            await _sedintaService.DeleteSessionAsync(id);
            return NoContent();
        }
    }
}
