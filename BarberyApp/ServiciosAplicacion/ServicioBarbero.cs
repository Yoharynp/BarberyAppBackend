
using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;
using BappDominio.Repositorios;
using BarberyApp.Comandos.BarberoComando;

namespace BarberyApp.ServiciosAplicacion
{
    public class ServicioBarbero
    {
        private readonly IBarberoRepositorio _barberoRepositorio;

        public ServicioBarbero(IBarberoRepositorio barberoRepositorio)
        {
            _barberoRepositorio = barberoRepositorio;
        }
        public async Task HandleCommand(AgregarBarbareocomando barbercomando)
        {
            var barbero = new Barbero(Guid.NewGuid());
            barbero.AsignarNombre(NombreBarbero.Crear(barbercomando.Nombre));
            barbero.AsignarEmail(EmailBarbero.Crear(barbercomando.Email));
            barbero.AsignarContraseña(Contraseñabarbero.Crear(barbercomando.Contraseña));
            barbero.AsignarApellido(ApellidoBarbero.Crear(barbercomando.Apellido));

            await _barberoRepositorio.Agregar(barbero);

        }
        public async Task HandleCommand(ModificarBarberocomando comando)
        {
            var barbero = await _barberoRepositorio.ObtenerPorId(comando.Id) ?? throw new Exception("Barbero no encontrado");
            barbero.AsignarNombre(NombreBarbero.Crear(comando.Nombre));
            barbero.AsignarEmail(EmailBarbero.Crear(comando.Email));
            barbero.AsignarContraseña(Contraseñabarbero.Crear(comando.Contraseña));
            barbero.AsignarApellido(ApellidoBarbero.Crear(comando.Apellido));

            await _barberoRepositorio.Actualizar(barbero);
        }

        public async Task HandleCommand(EliminarBarberocomando comando)
        {
            var barbero = await _barberoRepositorio.ObtenerPorId(comando.Id) ?? throw new Exception("Barbero no encontrado");
            await _barberoRepositorio.Eliminar(barbero);
        }
        public async Task<Barbero> ObtenerPorId(Guid id)
        {
            return await _barberoRepositorio.ObtenerPorId(id);
        }
        public async Task<List<Barbero>> ObtenerTodos()
        {
            return await _barberoRepositorio.ObtenerTodos();
        }

    }
}
