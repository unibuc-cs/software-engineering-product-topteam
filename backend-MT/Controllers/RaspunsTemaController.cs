using backend_MT.Models;
using backend_MT.Service.RaspunsTemaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaspunsTemaController : ControllerBase
    {
        private readonly IRaspunsTemaService _raspunsTemaService;

        public RaspunsTemaController(IRaspunsTemaService raspunsTemaService)
        {
            _raspunsTemaService = raspunsTemaService;
        }

        // GET: api/raspunsTema
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaspunsTema>>> GetAllResponses()
        {
            var raspunsuri = await _raspunsTemaService.GetAllResponsesAsync();
            return Ok(raspunsuri);
        }

        // GET: api/raspunsTema/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RaspunsTema>> GetResponseById(int id)
        {
            var raspunsTema = await _raspunsTemaService.GetResponseByIdAsync(id);
            if (raspunsTema == null)
            {
                return NotFound();
            }
            return Ok(raspunsTema);
        }

        // POST: api/raspunsTema
        [HttpPost]
        public async Task<ActionResult<RaspunsTema>> AddResponse(RaspunsTema raspunsTema)
        {
            await _raspunsTemaService.AddResponseAsync(raspunsTema);
            return CreatedAtAction(nameof(GetResponseById), new { id = raspunsTema.RaspunsTemaId }, raspunsTema); // Asumând că RaspunsTema are o proprietate Id
        }

        // PUT: api/raspunsTema/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id, RaspunsTema raspunsTema)
        {
            if (id != raspunsTema.RaspunsTemaId) // Verifică dacă ID-urile se potrivesc
            {
                return BadRequest();
            }

            await _raspunsTemaService.UpdateResponseAsync(raspunsTema);
            return NoContent();
        }

        // DELETE: api/raspunsTema/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            var raspunsTema = await _raspunsTemaService.GetResponseByIdAsync(id);
            if (raspunsTema == null)
            {
                return NotFound();
            }

            await _raspunsTemaService.DeleteResponseAsync(id);
            return NoContent();
        }
    }
}
