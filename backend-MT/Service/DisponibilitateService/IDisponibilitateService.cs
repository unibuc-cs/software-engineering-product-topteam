using backend_MT.Models;
using backend_MT.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_MT.Service.DisponibilitateService
{
    public interface IDisponibilitateService
    {
        Task<IEnumerable<DisponibilitateDTO>> GetAllDisponibilitatiAsync();
        Task<Disponibilitate> GetDisponibilitateByIdAsync(int id);
        Task<bool> AddDisponibilitateAsync(DisponibilitateDTO disponibilitate);
        Task UpdateDisponibilitateAsync(int id, DisponibilitateDTO disponibilitateDto);
        Task DeleteDisponibilitateAsync(int id);
    }
}