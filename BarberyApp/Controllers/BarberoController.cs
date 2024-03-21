using Microsoft.AspNetCore.Mvc;
using BarberyApp.ServiciosAplicacion;
using BarberyApp.Comandos;
using Microsoft.AspNetCore.Authorization;
using BarberyApp.Comandos.BarberoComando;
using BarberyApp.Infraestructura;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace BarberyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberoController : ControllerBase
    {
        private readonly IAutorizacionServicio autorizacionServicio;
        private readonly ServicioBarbero _barberoService;
        private readonly ContextoBarberyApp _dbContext;

        public BarberoController(IAutorizacionServicio autorizacionServicio, ServicioBarbero barberoService, ContextoBarberyApp contextoBarberyApp)
        {
            this.autorizacionServicio = autorizacionServicio;
            _barberoService = barberoService;
            _dbContext = contextoBarberyApp;
        }

        [Authorize]
        [HttpGet] 
        [Route("Lista")]
        public async Task<IActionResult> ObtenerTodosLosBarberos()
        {
            var barberos = await _barberoService.ObtenerTodos();
            return Ok(barberos);
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerBarbero")]
        public async Task<IActionResult> ObtenerBarbero()
        {
            // Obtener el ID del usuario autenticado desde los claims del token
            var usuarioiD = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Verificar si el ID del usuario es un Guid válido
            if (Guid.TryParse(usuarioiD, out Guid barberoId))
            {
                // Buscar el barbero en la base de datos utilizando el ID del usuario
                var barbero = await _dbContext.Barberos.FirstOrDefaultAsync(c => c.Id == barberoId);

                // Si se encuentra el barbero, devolverlo como respuesta
                if (barbero != null)
                {
                    return Ok(barbero);
                }
                else
                {
                    return NotFound("No se encontró el barbero.");
                }
            }
            else
            {
                // Si el ID del usuario no es un Guid válido, devolver un BadRequest
                return BadRequest("El identificador de usuario no es válido");
            }
        }


        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionPeticion autorizacionPeticion)
        {
            var respuesta = await autorizacionServicio.DevolverTokenBarbero(autorizacionPeticion);
            if (respuesta == null)
            {
                return Unauthorized();
            }

            return Ok(respuesta);
        }


        [HttpPost]
        [Route("AgregarBarbero")]
        public async Task<IActionResult> AgregarBarbero([FromBody] AgregarBarbareocomando comando)
        {
            await _barberoService.HandleCommand(comando);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarBarbero/{id}")]
        public async Task<IActionResult> ActualizarBarbero([FromBody] ModificarBarberocomando comando)
        {
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var usuario = await _dbContext.Barberos.FirstOrDefaultAsync(c => c.Id.ToString() == usuarioID);
            if (Guid.TryParse(usuarioID, out Guid barberoId))
            {
                await _barberoService.HandleCommand(comando);
                return Ok();
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("EliminarBarbero/{id}")]
        public async Task<IActionResult> EliminarBarbero(EliminarBarberocomando id)
        {
            await _barberoService.HandleCommand(id);
            return Ok();
        }

    }
}
