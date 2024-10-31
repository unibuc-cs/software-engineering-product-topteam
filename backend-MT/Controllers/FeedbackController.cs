//using backend_MT.Models;
//using backend_MT.Service.FeedbackService;
//using Microsoft.AspNetCore.Mvc;

//namespace backend_MT.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FeedbackController : ControllerBase
//    {
//        private readonly IFeedbackService _feedbackService;

//        public FeedbackController(IFeedbackService feedbackService)
//        {
//            _feedbackService = feedbackService;
//        }

//        // GET: api/feedback
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedbacks()
//        {
//            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
//            return Ok(feedbacks);
//        }

//        // GET: api/feedback/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Feedback>> GetFeedbackById(int id)
//        {
//            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
//            if (feedback == null)
//            {
//                return NotFound();
//            }
//            return Ok(feedback);
//        }

//        // POST: api/feedback
//        [HttpPost]
//        public async Task<ActionResult<Feedback>> AddFeedback(Feedback feedback)
//        {
//            await _feedbackService.AddFeedbackAsync(feedback);
//            return CreatedAtAction(nameof(GetFeedbackById), new { id = feedback.FeedbackId }, feedback); // Asumând că Feedback are o proprietate Id
//        }

//        // PUT: api/feedback/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateFeedback(int id, Feedback feedback)
//        {
//            if (id != feedback.FeedbackId) // Verifică dacă ID-urile se potrivesc
//            {
//                return BadRequest();
//            }

//            await _feedbackService.UpdateFeedbackAsync(feedback);
//            return NoContent();
//        }

//        // DELETE: api/feedback/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteFeedback(int id)
//        {
//            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
//            if (feedback == null)
//            {
//                return NotFound();
//            }

//            await _feedbackService.DeleteFeedbackAsync(id);
//            return NoContent();
//        }
//    }
//}
