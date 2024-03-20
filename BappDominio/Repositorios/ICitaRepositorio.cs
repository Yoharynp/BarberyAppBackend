using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Repositorios
{
    public interface ICitaRepositorio
    {
        Task<IEnumerable<Cita>> GetAllCitasAsync();
        Task<Cita> GetCitaByIdAsync(Guid id);
        Task AddCitaAsync(Cita cita);
        Task UpdateCitaAsync(Cita cita);
        Task DeleteCitaAsync(Guid id);
    }
}
