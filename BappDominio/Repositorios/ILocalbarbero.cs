using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Repositorios
{
    public interface ILocalbarbero
    {
        Task Agregar(Localbarbero localbarbero);
        Task Actualizar(Localbarbero localbarbero);
        Task Eliminar(Localbarbero localbarbero);
        Task<Localbarbero> ObtenerPorId(Guid id);
    }
}
