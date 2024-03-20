using BappDominio.Entidades;
using BappDominio.Repositorios;
using BarberyApp.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BappInfraestructura
{
    public class BarberoRepositorio : IBarberoRepositorio
    {
        private readonly ContextoBarberyApp _contextoBaseDeDatos;

        public BarberoRepositorio(ContextoBarberyApp contextoBaseDeDatos)
        {
            _contextoBaseDeDatos = contextoBaseDeDatos;
        }
        public Task Actualizar(Barbero barbero)
        {
            _contextoBaseDeDatos.Barberos.Update(barbero);
            return _contextoBaseDeDatos.SaveChangesAsync();
        }

        public async Task Agregar(Barbero barbero)
        {
            await _contextoBaseDeDatos.Barberos.AddAsync(barbero);
            await _contextoBaseDeDatos.SaveChangesAsync();
        }

        public Task Eliminar(Barbero barbero)
        {
            _contextoBaseDeDatos.Barberos.Remove(barbero);
            return _contextoBaseDeDatos.SaveChangesAsync();
        }

        public Task<Barbero> ObtenerPorEmail(string email)
        {
            return Task.FromResult(_contextoBaseDeDatos.Barberos.FirstOrDefault(x => x.Email == email));
        }

        public Task<Barbero> ObtenerPorId(Guid id)
        {
            return Task.FromResult(_contextoBaseDeDatos.Barberos.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Barbero>> ObtenerTodos()
        {
            _ = _contextoBaseDeDatos.Barberos.ToList();
            return Task.FromResult(_contextoBaseDeDatos.Barberos.ToList());
        }
    }
}
