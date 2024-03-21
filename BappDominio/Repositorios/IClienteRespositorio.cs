using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Repositorios
{
    public interface IClienteRespositorio
    {
        Task Agregar(Cliente cliente);
        Task Actualizar(Cliente cliente);
        Task Eliminar(Cliente cliente);
        Task<Cliente> ObtenerPorId(Guid id);
        Task<IEnumerable<Cliente>> ObtenerTodos();
    }
}
