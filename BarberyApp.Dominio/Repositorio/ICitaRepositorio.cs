using BarberyApp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Repositorio
{
    public interface ICitaRepositorio
    {
        Task Agregar(Cita cita);
        Task Actualizar(Cita cita);
        Task<Cita> ObtenerPorId(Guid id);
    }
}
