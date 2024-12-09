using backend_MT.Models;
using backend_MT.Service.AbonamentService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonamentController : ControllerBase
    {
        private readonly IAbonamentService _abonamentService;

        public AbonamentController(IAbonamentService abonamentService)
        {
            _abonamentService = abonamentService;
        }

        // GET: api/abonament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonament>>> GetAllSubscriptions()
        {
            var abonamente = await _abonamentService.GetAllSubscriptionsAsync();
            return Ok(abonamente);
        }

        // GET: api/abonament/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Abonament>> GetSubscriptionById(int id)
        {
            var abonament = await _abonamentService.GetSubscriptionByIdAsync(id);
            if (abonament == null)
            {
                return NotFound();
            }
            return Ok(abonament);
        }

        // POST: api/abonament
        [HttpPost]
        public async Task<ActionResult<Abonament>> AddSubscription(Abonament abonament)
        {
            await _abonamentService.AddSubscriptionAsync(abonament);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = abonament.abonamentId }, abonament);
        }

        // PUT: api/abonament/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(int id, Abonament abonament)
        {
            if (id != abonament.abonamentId)
            {
                return BadRequest();
            }

            await _abonamentService.UpdateSubscriptionAsync(abonament);
            return NoContent();
        }

        // DELETE: api/abonament/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var abonament = await _abonamentService.GetSubscriptionByIdAsync(id);
            if (abonament == null)
            {
                return NotFound();
            }

            await _abonamentService.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}
