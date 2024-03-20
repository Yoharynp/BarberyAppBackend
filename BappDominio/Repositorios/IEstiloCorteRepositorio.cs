using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Repositorios
{
    public interface IEstiloCorteRepositorio
    {
        Task AgregarEstiloCorte(EstiloCorte estiloCorte);
        Task ModificarEstiloCorte(Guid id, EstiloCorte estiloCorte);
        Task EliminarEstiloCorte(Guid id);
        Task <EstiloCorte>ObtenerPorId(Guid id);
        Task<List<EstiloCorte>>ObtenerTodos();
    }
}
