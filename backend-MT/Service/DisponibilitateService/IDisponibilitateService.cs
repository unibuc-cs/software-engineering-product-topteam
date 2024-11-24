using backend_MT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.DisponibilitateService
{
    public interface IDisponibilitateService
    {
        Task<IEnumerable<Disponibilitate>> GetAllDisponibilitatiAsync();
        Task<Disponibilitate> GetDisponibilitateByIdAsync(int id);
        Task AddDisponibilitateAsync(Disponibilitate disponibilitate);
        Task UpdateDisponibilitateAsync(Disponibilitate disponibilitate);
        Task DeleteDisponibilitateAsync(int id);
    }
}