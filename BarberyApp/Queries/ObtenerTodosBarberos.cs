using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;
using BappDominio.Repositorios;
using MediatR;

namespace BarberyApp.Queries
{
    public class ObtenerTodosBarberos
    {
        private readonly IBarberoRepositorio _barberoRepository;

        public ObtenerTodosBarberos(IBarberoRepositorio barberoRepository)
        {
            _barberoRepository = barberoRepository;
        }

        public async Task<Barbero> ObtenerPorID(Guid id)
        {
            var response = await _barberoRepository.ObtenerPorId(BarberoId.Crear(id));
            return response;
        }
    }
}
