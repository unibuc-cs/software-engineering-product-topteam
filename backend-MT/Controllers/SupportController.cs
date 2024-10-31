//using backend_MT.Models;
//using backend_MT.Repositories.SupportRepository;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace backend_MT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SupportController : ControllerBase
//    {
//        private readonly ISupportRepository _supportRepository;

//        public SupportController(ISupportRepository supportRepository)
//        {
//            _supportRepository = supportRepository;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Support>>> GetAllSupportMessages()
//        {
//            var messages = await _supportRepository.GetAllSupportMessagesAsync();
//            return Ok(messages);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Support>> GetSupportMessageById(int id)
//        {
//            var message = await _supportRepository.GetSupportMessageByIdAsync(id);
//            if (message == null)
//            {
//                return NotFound();
//            }
//            return Ok(message);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Support>> AddSupportMessage(Support support)
//        {
//            await _supportRepository.AddSupportMessageAsync(support);
//            return CreatedAtAction(nameof(GetSupportMessageById), new { id = support.SupportId }, support);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateSupportMessage(int id, Support support)
//        {
//            if (id != support.SupportId)
//            {
//                return BadRequest();
//            }

//            await _supportRepository.UpdateSupportMessageAsync(support);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteSupportMessage(int id)
//        {
//            await _supportRepository.DeleteSupportMessageAsync(id);
//            return NoContent();
//        }
//    }
//}
