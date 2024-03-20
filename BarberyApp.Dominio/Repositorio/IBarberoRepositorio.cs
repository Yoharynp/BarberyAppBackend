using BarberyApp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Repositorio
{
    public interface IBarberoRepositorio
    {
        Task Agregar(Barbero barbero);
        Task Actualizar(Barbero barbero);
        Task Eliminar(Barbero barbero);
        Task<Barbero> ObtenerPorId(Guid id);
    }
}
