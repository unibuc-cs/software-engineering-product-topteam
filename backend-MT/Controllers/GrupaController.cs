using backend_MT.Models;
using backend_MT.Service.GrupaService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupaController : ControllerBase
    {
        private readonly IGrupaService _grupaService;

        public GrupaController(IGrupaService grupaService)
        {
            _grupaService = grupaService;
        }

        // GET: api/grupa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupa>>> GetAllGroups()
        {
            var grupe = await _grupaService.GetAllGroupsAsync();
            return Ok(grupe);
        }

        // GET: api/grupa/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupa>> GetGroupById(int id)
        {
            var grupa = await _grupaService.GetGroupByIdAsync(id);
            if (grupa == null)
            {
                return NotFound();
            }
            return Ok(grupa);
        }

        // POST: api/grupa
        [HttpPost]
        public async Task<ActionResult<Grupa>> AddGroup(Grupa grupa)
        {
            await _grupaService.AddGroupAsync(grupa);
            return CreatedAtAction(nameof(GetGroupById), new { id = grupa.GrupaId }, grupa); // Asumând că Grupa are o proprietate Id
        }

        // PUT: api/grupa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, Grupa grupa)
        {
            if (id != grupa.GrupaId) // Verifică dacă ID-urile se potrivesc
            {
                return BadRequest();
            }

            await _grupaService.UpdateGroupAsync(grupa);
            return NoContent();
        }

        // DELETE: api/grupa/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var grupa = await _grupaService.GetGroupByIdAsync(id);
            if (grupa == null)
            {
                return NotFound();
            }

            await _grupaService.DeleteGroupAsync(id);
            return NoContent();
        }
    }
}
