using backend_MT.Models;
using backend_MT.Models.DTOs;
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
        public async Task<ActionResult<IEnumerable<RaspunsTemaDTO>>> GetAllResponses()
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
        public async Task<ActionResult> AddResponse(RaspunsTemaDTO raspunsTema)
        {
            if (await _raspunsTemaService.AddResponseAsync(raspunsTema))
                return Ok();
            return BadRequest();
        }

        // PUT: api/raspunsTema/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResponse(int id, RaspunsTemaDTO raspunsTema)
        {
            await _raspunsTemaService.UpdateResponseAsync(id, raspunsTema);
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
