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
    public class EstiloCorteRepositorio : IEstiloCorteRepositorio
    {
        private readonly ContextoBarberyApp _contextobasededatos;

        public EstiloCorteRepositorio(ContextoBarberyApp contextobasededatos)
        {
            _contextobasededatos = contextobasededatos;
        }
        public Task AgregarEstiloCorte(EstiloCorte estiloCorte)
        {
           _contextobasededatos.EstiloCorte.Add(estiloCorte);
            return _contextobasededatos.SaveChangesAsync();
        }
        public Task EliminarEstiloCorte(Guid id)
        {
            _contextobasededatos.EstiloCorte.Remove(_contextobasededatos.EstiloCorte.Find(id));
            return _contextobasededatos.SaveChangesAsync();
        }

        public Task ModificarEstiloCorte(Guid id, EstiloCorte estiloCorte)
        {
            _contextobasededatos.EstiloCorte.Update(estiloCorte);
            return _contextobasededatos.SaveChangesAsync();
        }

        public async Task<EstiloCorte> ObtenerPorId(Guid id)
        {
            _contextobasededatos.EstiloCorte.Find(id);
            return await _contextobasededatos.EstiloCorte.FindAsync((Guid)id);
        }

        public Task<List<EstiloCorte>> ObtenerTodos()
        {
            _ = _contextobasededatos.EstiloCorte.ToList();
            return Task.FromResult(_contextobasededatos.EstiloCorte.ToList());
        }
    }
}
