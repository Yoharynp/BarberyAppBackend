using BappDominio.Entidades;
using BappDominio.ObjetosValor.Cliente;
using BappDominio.Repositorios;
using BarberyApp.Comandos.ClienteComandos;

namespace BarberyApp.ServiciosAplicacion
{
    public class ServicioCliente
    {
        private readonly IClienteRespositorio _clienteRespositorio;

        public ServicioCliente(IClienteRespositorio clienteRespositorio)
        {
            _clienteRespositorio = clienteRespositorio;
        }

        public async Task HandleCommand(AgregarClienteComando clienteComando)
        {
            var cliente = new Cliente(Guid.NewGuid());
            cliente.AsignarNombre(ClienteNombre.Crear(clienteComando.Nombre));
            cliente.AsignarEmail(ClienteEmail.Crear(clienteComando.Email));
            cliente.AsignarContraseña(ClienteContraseña.Crear(clienteComando.Contraseña));
            cliente.AsignarApellido(ClienteApellido.Crear(clienteComando.Apellido));

            await _clienteRespositorio.Agregar(cliente);
        }

        public async Task HandleCommand(ModificarClienteComando comando)
        {
            var cliente = await _clienteRespositorio.ObtenerPorId(comando.Id) ?? throw new Exception("Cliente no encontrado");
            cliente.AsignarNombre(ClienteNombre.Crear(comando.Nombre));

            await _clienteRespositorio.Actualizar(cliente);
        }

        public async Task HandleCommand(Eliminarclientecomando comando)
        {
            var cliente = await _clienteRespositorio.ObtenerPorId(comando.id) ?? throw new Exception("Cliente no encontrado");
            await _clienteRespositorio.Eliminar(cliente);
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            return await _clienteRespositorio.ObtenerTodos();
        }

    }
}
