using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Repositories.MesajRepository
{
    public interface IMesajRepository
    {
        Task<IEnumerable<Mesaj>> GetAllMessagesAsync();
        Task<Mesaj> GetMessageByIdAsync(int id);
        Task<bool> AddMessageAsync(Mesaj mesaj);
        Task UpdateMessageAsync(Mesaj mesaj);
        Task DeleteMessageAsync(int id);
    }
}