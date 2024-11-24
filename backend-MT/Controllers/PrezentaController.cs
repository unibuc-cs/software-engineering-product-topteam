using backend_MT.Models;
using backend_MT.Service.PrezentaService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrezentaController : ControllerBase
    {
        private readonly IPrezentaService _prezentaService;

        public PrezentaController(IPrezentaService prezentaService)
        {
            _prezentaService = prezentaService;
        }

        // GET: api/prezenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prezenta>>> GetAllPrezente()
        {
            var prezente = await _prezentaService.GetAllPrezenteAsync();
            return Ok(prezente);
        }

        // GET: api/prezenta/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Prezenta>> GetPrezentaById(int id)
        {
            var prezenta = await _prezentaService.GetPrezentaByIdAsync(id);
            if (prezenta == null)
            {
                return NotFound();
            }
            return Ok(prezenta);
        }

        // POST: api/prezenta
        [HttpPost]
        public async Task<ActionResult<Prezenta>> AddPrezenta(Prezenta prezenta)
        {
            await _prezentaService.AddPrezentaAsync(prezenta);
            return CreatedAtAction(nameof(GetPrezentaById), new { id = prezenta.prezentaId }, prezenta);
        }

        // PUT: api/prezenta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrezenta(int id, Prezenta prezenta)
        {
            if (id != prezenta.prezentaId)
            {
                return BadRequest();
            }

            await _prezentaService.UpdatePrezentaAsync(prezenta);
            return NoContent();
        }

        // DELETE: api/prezenta/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrezenta(int id)
        {
            var prezenta = await _prezentaService.GetPrezentaByIdAsync(id);
            if (prezenta == null)
            {
                return NotFound();
            }

            await _prezentaService.DeletePrezentaAsync(id);
            return NoContent();
        }
    }
}
