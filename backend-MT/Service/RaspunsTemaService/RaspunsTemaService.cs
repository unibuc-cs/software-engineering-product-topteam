using backend_MT.Models;
using backend_MT.Repositories.RaspunsTemaRepository;

namespace backend_MT.Service.RaspunsTemaService
{
    public class RaspunsTemaService : IRaspunsTemaService
    {
        private readonly IRaspunsTemaRepository _raspunsTemaRepository;

        public RaspunsTemaService(IRaspunsTemaRepository raspunsTemaRepository)
        {
            _raspunsTemaRepository = raspunsTemaRepository;
        }

        public async Task<IEnumerable<RaspunsTema>> GetAllResponsesAsync()
        {
            return await _raspunsTemaRepository.GetAllResponsesAsync();
        }

        public async Task<RaspunsTema> GetResponseByIdAsync(int id)
        {
            return await _raspunsTemaRepository.GetResponseByIdAsync(id);
        }

        public async Task AddResponseAsync(RaspunsTema raspunsTema)
        {
            await _raspunsTemaRepository.AddResponseAsync(raspunsTema);
        }

        public async Task UpdateResponseAsync(RaspunsTema raspunsTema)
        {
            await _raspunsTemaRepository.UpdateResponseAsync(raspunsTema);
        }

        public async Task DeleteResponseAsync(int id)
        {
            await _raspunsTemaRepository.DeleteResponseAsync(id);
        }
    }
}
