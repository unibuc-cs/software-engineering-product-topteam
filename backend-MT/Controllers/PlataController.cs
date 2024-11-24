using backend_MT.Models;
using backend_MT.Service.PlataService;
using Microsoft.AspNetCore.Mvc;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataController : ControllerBase
    {
        private readonly IPlataService _plataService;

        public PlataController(IPlataService plataService)
        {
            _plataService = plataService;
        }

        // GET: api/plata
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plata>>> GetAllPayments()
        {
            var plati = await _plataService.GetAllPaymentsAsync();
            return Ok(plati);
        }

        // GET: api/plata/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Plata>> GetPaymentById(int id)
        {
            var plata = await _plataService.GetPaymentByIdAsync(id);
            if (plata == null)
            {
                return NotFound();
            }
            return Ok(plata);
        }

        // POST: api/plata
        [HttpPost]
        public async Task<ActionResult<Plata>> AddPayment(Plata plata)
        {
            await _plataService.AddPaymentAsync(plata);
            return CreatedAtAction(nameof(GetPaymentById), new { id = plata.plataId }, plata); // Asumând că Plata are o proprietate Id
        }

        // PUT: api/plata/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, Plata plata)
        {
            if (id != plata.plataId) // Verifică dacă ID-urile se potrivesc
            {
                return BadRequest();
            }

            await _plataService.UpdatePaymentAsync(plata);
            return NoContent();
        }

        // DELETE: api/plata/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var plata = await _plataService.GetPaymentByIdAsync(id);
            if (plata == null)
            {
                return NotFound();
            }

            await _plataService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
