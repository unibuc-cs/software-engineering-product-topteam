using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.PrezentaService
{
    public interface IPrezentaService
    {
        Task<IEnumerable<Prezenta>> GetAllPrezenteAsync();
        Task<Prezenta> GetPrezentaByIdAsync(int id);
        Task AddPrezentaAsync(Prezenta prezenta);
        Task UpdatePrezentaAsync(Prezenta prezenta);
        Task DeletePrezentaAsync(int id);
    }
}