using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.FeedbackService
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync();
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task<bool> AddFeedbackAsync(FeedbackDTO feedback);
        Task UpdateFeedbackAsync(int id, FeedbackDTO feedbackDto);
		Task DeleteFeedbackAsync(int id);
    }
}
