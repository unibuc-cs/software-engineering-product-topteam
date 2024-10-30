using backend_MT.Models;

namespace backend_MT.Service.MesajService
{
    public interface IMesajService
    {
        Task<IEnumerable<Mesaj>> GetAllMessagesAsync();
        Task<Mesaj> GetMessageByIdAsync(int id);
        Task AddMessageAsync(Mesaj mesaj);
        Task UpdateMessageAsync(Mesaj mesaj);
        Task DeleteMessageAsync(int id);
    }
}
