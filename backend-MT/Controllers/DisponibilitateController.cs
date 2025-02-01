using backend_MT.Models;
using backend_MT.Models.DTOs;
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
        public async Task<ActionResult<IEnumerable<DisponibilitateDTO>>> GetAllDisponibilitati()
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
        public async Task<IActionResult> AddDisponibilitate(DisponibilitateDTO disponibilitate)
        {
            if (await _disponibilitateService.AddDisponibilitateAsync(disponibilitate))
                return Ok();
            return BadRequest();
        }

        // PUT: api/disponibilitate/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisponibilitate(int id, DisponibilitateDTO disponibilitate)
        {

            await _disponibilitateService.UpdateDisponibilitateAsync(id, disponibilitate);
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
