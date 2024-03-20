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
    public class LocalBarberoRepositorio : ILocalbarbero
    {
        private readonly ContextoBarberyApp _contextobasededatos;

        public LocalBarberoRepositorio(ContextoBarberyApp contextobasededatos)
        {
            _contextobasededatos = contextobasededatos;
        }

        public Task Actualizar(Localbarbero localbarbero)
        {
            _contextobasededatos.LocalBarbero.Update(localbarbero);
            return _contextobasededatos.SaveChangesAsync();
        }

        public Task Agregar(Localbarbero localbarbero)
        {
            _contextobasededatos.LocalBarbero.Add(localbarbero);
            return _contextobasededatos.SaveChangesAsync();
        }

        public Task Eliminar(Localbarbero localbarbero)
        {
            _contextobasededatos.LocalBarbero.Remove(localbarbero);
            return _contextobasededatos.SaveChangesAsync();
        }

        public Task<Localbarbero> ObtenerPorId(Guid id)
        {
            _contextobasededatos.LocalBarbero.Find(id);
            return Task.FromResult(_contextobasededatos.LocalBarbero.FirstOrDefault(x => x.Id == id));
        }
    }
}
