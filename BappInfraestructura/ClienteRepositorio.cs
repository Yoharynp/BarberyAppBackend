using BappDominio.Entidades;
using BappDominio.Repositorios;
using BarberyApp.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappInfraestructura
{
    public class ClienteRepositorio : IClienteRespositorio
    {
        private readonly ContextoBarberyApp _contextoBaseDeDatos;

        public ClienteRepositorio(ContextoBarberyApp contextoBaseDeDatos)
        {
            _contextoBaseDeDatos = contextoBaseDeDatos;
        }
        public Task Actualizar(Cliente cliente)
        {
            _contextoBaseDeDatos.Clientes.Update(cliente);
            return _contextoBaseDeDatos.SaveChangesAsync();
        }

        public async Task Agregar(Cliente cliente)
        {
            await _contextoBaseDeDatos.Clientes.AddAsync(cliente);
            await _contextoBaseDeDatos.SaveChangesAsync();
        }

        public Task Eliminar(Cliente cliente)
        {
            _contextoBaseDeDatos.Clientes.Remove(cliente);
            return _contextoBaseDeDatos.SaveChangesAsync();
        }

        public Task<Cliente> ObtenerPorId(Guid id)
        {
            _ = _contextoBaseDeDatos.Clientes.FindAsync((Guid)id);
            return Task.FromResult(_contextoBaseDeDatos.Clientes.Find(id));
        }

        public Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            return Task.FromResult(_contextoBaseDeDatos.Clientes.AsEnumerable());
        }
    }
}
