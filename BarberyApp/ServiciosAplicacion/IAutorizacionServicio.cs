using BappDominio.Entidades;
using BarberyApp.Comandos;

namespace BarberyApp.ServiciosAplicacion
{
    public interface IAutorizacionServicio
    {
        Task<AutorizacionRespuesta> DevolverTokenBarbero(AutorizacionPeticion peticion);
        Task<AutorizacionRespuesta> DevolverTokenCliente(AutorizacionPeticion peticion);
    }
}
