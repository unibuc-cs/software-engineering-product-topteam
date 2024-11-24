using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.ParticipareGrupaRepository
{
    public interface IParticipareGrupaRepository
    {
        Task<IEnumerable<ParticipareGrupa>> GetAllParticipariAsync();
        Task<ParticipareGrupa> GetParticipareByIdAsync(int id);
        Task AddParticipareAsync(ParticipareGrupa participare);
        Task UpdateParticipareAsync(ParticipareGrupa participare);
        Task DeleteParticipareAsync(int id);
    }
}