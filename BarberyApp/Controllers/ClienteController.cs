using BappDominio.ObjetosValor.Cliente;
using BarberyApp.Comandos;
using BarberyApp.Comandos.ClienteComandos;
using BarberyApp.Infraestructura;
using BarberyApp.ServiciosAplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BarberyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ServicioCliente _clienteService;
        private readonly IAutorizacionServicio _autorizacionServicio;
        private readonly ContextoBarberyApp _dbContext;

        public ClienteController(ServicioCliente clienteService, IAutorizacionServicio autorizacionServicio, ContextoBarberyApp dbContext)
        {
            _clienteService = clienteService;
            _autorizacionServicio = autorizacionServicio;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("AgregarCliente")]
        public async Task<IActionResult> AgregarCliente([FromBody] AgregarClienteComando comando)
        {
            await _clienteService.HandleCommand(comando);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerCliente")]
        public async Task<IActionResult> ObtenerCliente()
        {
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(usuarioID, out Guid clienteId))
            {
                var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == clienteId);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return NotFound("No se encontró el cliente.");
                }
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

        [HttpGet]
        [Route("ObtenerTodosCliente")]
        public async Task<IActionResult> ObtenerTodosCliente()
        {
            var clientes = await _clienteService.ObtenerTodos();
            return Ok(clientes);
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerClientePorId/{id}")]
        public async Task<IActionResult> ObtenerClientePorId(Guid id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NotFound("No se encontró el cliente.");
            }
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionPeticion comando)
        {
            var respuesta = await _autorizacionServicio.DevolverTokenCliente
                (comando);
            if (respuesta == null)
            {
                return Unauthorized();
            }
            return Ok(respuesta);
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarCliente/{id}")]
        public async Task<IActionResult> ActualizarCliente([FromBody] ModificarClienteComando comando)
        {
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usuario = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id.ToString() == usuarioID);
            if (Guid.TryParse(usuarioID, out Guid clienteId))
            {
                if (clienteId != comando.Id)
                {
                    return Unauthorized();
                }
                else
                {
                    usuario.AsignarNombre(ClienteNombre.Crear(comando.Nombre));
                    usuario.AsignarApellido(ClienteApellido.Crear(comando.Apellido));
                    usuario.AsignarEmail(ClienteEmail.Crear(comando.Email));
                    usuario.AsignarContraseña(ClienteContraseña.Crear(comando.Contraseña));
                    await _dbContext.SaveChangesAsync();
                    return Ok("Cliente Actaulizado");

                }
                
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarClienteAdmin/{id}")]
        public async Task<IActionResult> ActualizarClienteAdmin([FromBody] ModificarClienteComando comando)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == comando.Id);
            if (cliente != null)
            {
                cliente.AsignarNombre(ClienteNombre.Crear(comando.Nombre));
                cliente.AsignarApellido(ClienteApellido.Crear(comando.Apellido));
                cliente.AsignarEmail(ClienteEmail.Crear(comando.Email));
                cliente.AsignarContraseña(ClienteContraseña.Crear(comando.Contraseña));
                await _dbContext.SaveChangesAsync();
                return Ok("Cliente Actaulizado");
            }
            else
            {
                return NotFound("No se encontró el cliente.");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("EliminarCliente/{id}")]
        public async Task<IActionResult> EliminarCliente(Guid id)
        {
            var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente != null)
            {
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
                return Ok("Cliente Eliminado");
            }
            else
            {
                return NotFound("No se encontró el cliente.");
            }
        }
    }
}
