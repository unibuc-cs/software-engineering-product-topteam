using AutoMapper;
using backend_MT.Models;
using backend_MT.Models.DTOs;
using backend_MT.Repositories.FeedbackRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.FeedbackService
{
	public class FeedbackService : IFeedbackService
	{
		private readonly IFeedbackRepository _feedbackRepository;
		private readonly IMapper _mapper;

		public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
		{
			_feedbackRepository = feedbackRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync()
		{
			var feedbacks = await _feedbackRepository.GetAllFeedbacksAsync();
			return _mapper.Map<IEnumerable<FeedbackDTO>>(feedbacks);
		}

		public async Task<Feedback> GetFeedbackByIdAsync(int id)
		{
			return await _feedbackRepository.GetFeedbackByIdAsync(id);
		}

		public async Task<bool> AddFeedbackAsync(FeedbackDTO feedbackDto)
		{
			var feedback = _mapper.Map<Feedback>(feedbackDto);
			return await _feedbackRepository.AddFeedbackAsync(feedback);
		}

		public async Task UpdateFeedbackAsync(int id, FeedbackDTO feedbackDto)
		{
			var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
			_mapper.Map(feedbackDto, feedback);
			await _feedbackRepository.UpdateFeedbackAsync(feedback);
		}

		public async Task DeleteFeedbackAsync(int id)
		{
			await _feedbackRepository.DeleteFeedbackAsync(id);
		}
	}
}
