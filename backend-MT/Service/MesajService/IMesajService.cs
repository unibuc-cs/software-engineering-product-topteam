using backend_MT.Models;
using backend_MT.Models.DTOs;

namespace backend_MT.Service.MesajService
{
    public interface IMesajService
    {
        Task<IEnumerable<MesajDTO>> GetAllMessagesAsync();
        Task<Mesaj> GetMessageByIdAsync(int id);
        Task<bool> AddMessageAsync(MesajDTO mesaj);
        Task UpdateMessageAsync(int id, MesajDTO mesaj);
        Task DeleteMessageAsync(int id);
    }
}
