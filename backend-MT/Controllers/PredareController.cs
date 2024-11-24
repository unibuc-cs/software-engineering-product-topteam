using backend_MT.Models;
using backend_MT.Service.PredareService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredareController : ControllerBase
    {
        private readonly IPredareService _predareService;

        public PredareController(IPredareService predareService)
        {
            _predareService = predareService;
        }

        // GET: api/predare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Predare>>> GetAllPredari()
        {
            var predari = await _predareService.GetAllPredariAsync();
            return Ok(predari);
        }

        // GET: api/predare/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Predare>> GetPredareById(int id)
        {
            var predare = await _predareService.GetPredareByIdAsync(id);
            if (predare == null)
            {
                return NotFound();
            }
            return Ok(predare);
        }

        // POST: api/predare
        [HttpPost]
        public async Task<ActionResult<Predare>> AddPredare(Predare predare)
        {
            await _predareService.AddPredareAsync(predare);
            return CreatedAtAction(nameof(GetPredareById), new { id = predare.predareId }, predare);
        }

        // PUT: api/predare/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePredare(int id, Predare predare)
        {
            if (id != predare.predareId)
            {
                return BadRequest();
            }

            await _predareService.UpdatePredareAsync(predare);
            return NoContent();
        }

        // DELETE: api/predare/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredare(int id)
        {
            var predare = await _predareService.GetPredareByIdAsync(id);
            if (predare == null)
            {
                return NotFound();
            }

            await _predareService.DeletePredareAsync(id);
            return NoContent();
        }
    }
}
