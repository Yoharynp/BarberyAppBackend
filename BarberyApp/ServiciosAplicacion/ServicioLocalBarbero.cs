using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;
using BappDominio.ObjetosValor.LocalBarbero;
using BappDominio.Repositorios;
using BarberyApp.Comandos.LocalBarberoComandos;
using System.Reflection.Metadata;

namespace BarberyApp.ServiciosAplicacion
{
    public class ServicioLocalBarbero
    {
        private readonly ILocalbarbero _localbarbero;

        public ServicioLocalBarbero(ILocalbarbero localbarbero)
        {
            _localbarbero = localbarbero;
        }

        public async Task HandleCommand(AgregarLocalBarberoComando localBarberoComando, Guid barberoId)
        {
            var localBarbero = new Localbarbero(Guid.NewGuid());
            localBarbero.AsignarNombre(localBarberoComando.NombreBarberia);
            localBarbero.AsignarUbicacion(localBarberoComando.Ubicacion);
            localBarbero.AsignarTelefono(localBarberoComando.NumeroContacto);
            localBarbero.AsignarDescripcion(localBarberoComando.Descripcion);
            localBarbero.AsignarHorario(localBarberoComando.Horario);
            localBarbero.AsignarFoto(localBarberoComando.Foto);
            localBarbero.AsignarBarberoId(barberoId);
            await _localbarbero.Agregar(localBarbero);
        }

        public async Task HandleCommand(ModificarLocalBarberoComando modificarLocalBarberoComando)
        {
            var localBarbero = await _localbarbero.ObtenerPorId(modificarLocalBarberoComando.Id);
            localBarbero.AsignarNombre(modificarLocalBarberoComando.NombreBarberia);
            localBarbero.AsignarUbicacion(modificarLocalBarberoComando.Ubicacion);
            localBarbero.AsignarTelefono(modificarLocalBarberoComando.NumeroContacto);
            localBarbero.AsignarDescripcion(modificarLocalBarberoComando.Descripcion);
            localBarbero.AsignarHorario(modificarLocalBarberoComando.Horario);
            localBarbero.AsignarFoto(modificarLocalBarberoComando.Foto);
            await _localbarbero.Actualizar(localBarbero);
        }

    }
}
