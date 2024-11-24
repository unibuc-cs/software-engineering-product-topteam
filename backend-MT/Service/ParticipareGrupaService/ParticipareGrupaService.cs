using backend_MT.Models;
using backend_MT.Repositories.ParticipareGrupaRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.ParticipareGrupaService
{
    public class ParticipareGrupaService : IParticipareGrupaService
    {
        private readonly IParticipareGrupaRepository _participareGrupaRepository;

        public ParticipareGrupaService(IParticipareGrupaRepository participareGrupaRepository)
        {
            _participareGrupaRepository = participareGrupaRepository;
        }

        public async Task<IEnumerable<ParticipareGrupa>> GetAllParticipariAsync()
        {
            return await _participareGrupaRepository.GetAllParticipariAsync();
        }

        public async Task<ParticipareGrupa> GetParticipareByIdAsync(int id)
        {
            return await _participareGrupaRepository.GetParticipareByIdAsync(id);
        }

        public async Task AddParticipareAsync(ParticipareGrupa participare)
        {
            await _participareGrupaRepository.AddParticipareAsync(participare);
        }

        public async Task UpdateParticipareAsync(ParticipareGrupa participare)
        {
            await _participareGrupaRepository.UpdateParticipareAsync(participare);
        }

        public async Task DeleteParticipareAsync(int id)
        {
            await _participareGrupaRepository.DeleteParticipareAsync(id);
        }
    }
}