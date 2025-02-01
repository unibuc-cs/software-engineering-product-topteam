using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.SupportRepository;
using backend_MT.Service.SupportService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;

        public SupportController(ISupportService supportService)
        {
            _supportService = supportService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupportDTO>>> GetAllSupportMessages()
        {
            var messages = await _supportService.GetAllSupportMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Support>> GetSupportMessageById(int id)
        {
            var message = await _supportService.GetSupportMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult> AddSupportMessage(SupportDTO support)
        {
            if (await _supportService.AddSupportMessageAsync(support))
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSupportMessage(int id, SupportDTO support)
        {
            await _supportService.UpdateSupportMessageAsync(id, support);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupportMessage(int id)
        {
            await _supportService.DeleteSupportMessageAsync(id);
            return NoContent();
        }
    }
}
