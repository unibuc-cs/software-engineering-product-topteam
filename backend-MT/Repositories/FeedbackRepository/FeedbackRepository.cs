using backend_MT.Data;
using backend_MT.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.FeedbackRepository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _context.feedback.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.feedback.FindAsync(id);
        }

        public async Task AddFeedbackAsync(Feedback feedback)
        {
            await _context.feedback.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            _context.feedback.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.feedback.FindAsync(id);
            if (feedback != null)
            {
                _context.feedback.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}