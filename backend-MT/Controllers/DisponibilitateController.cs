using backend_MT.Models;
using backend_MT.Service.DisponibilitateService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilitateController : ControllerBase
    {
        private readonly IDisponibilitateService _disponibilitateService;

        public DisponibilitateController(IDisponibilitateService disponibilitateService)
        {
            _disponibilitateService = disponibilitateService;
        }

        // GET: api/disponibilitate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disponibilitate>>> GetAllDisponibilitati()
        {
            var disponibilitati = await _disponibilitateService.GetAllDisponibilitatiAsync();
            return Ok(disponibilitati);
        }

        // GET: api/disponibilitate/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Disponibilitate>> GetDisponibilitateById(int id)
        {
            var disponibilitate = await _disponibilitateService.GetDisponibilitateByIdAsync(id);
            if (disponibilitate == null)
            {
                return NotFound();
            }
            return Ok(disponibilitate);
        }

        // POST: api/disponibilitate
        [HttpPost]
        public async Task<ActionResult<Disponibilitate>> AddDisponibilitate(Disponibilitate disponibilitate)
        {
            await _disponibilitateService.AddDisponibilitateAsync(disponibilitate);
            return CreatedAtAction(nameof(GetDisponibilitateById), new { id = disponibilitate.disponibilitateId }, disponibilitate);
        }

        // PUT: api/disponibilitate/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisponibilitate(int id, Disponibilitate disponibilitate)
        {
            if (id != disponibilitate.disponibilitateId)
            {
                return BadRequest();
            }

            await _disponibilitateService.UpdateDisponibilitateAsync(disponibilitate);
            return NoContent();
        }

        // DELETE: api/disponibilitate/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilitate(int id)
        {
            var disponibilitate = await _disponibilitateService.GetDisponibilitateByIdAsync(id);
            if (disponibilitate == null)
            {
                return NotFound();
            }

            await _disponibilitateService.DeleteDisponibilitateAsync(id);
            return NoContent();
        }
    }
}
