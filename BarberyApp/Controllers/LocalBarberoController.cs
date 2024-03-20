using BarberyApp.Comandos.LocalBarberoComandos;
using BarberyApp.ServiciosAplicacion;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using BarberyApp.Infraestructura;

namespace BarberyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalBarberoController : ControllerBase
    {
        private readonly ServicioLocalBarbero _servicioLocalBarbero;
        private readonly ContextoBarberyApp _dbContext;

        public LocalBarberoController(ServicioLocalBarbero servicioLocalBarbero, ContextoBarberyApp dbContext)
        {
            _servicioLocalBarbero = servicioLocalBarbero;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AgregarLocalBarbero([FromBody] AgregarLocalBarberoComando localBarberoComando)
        {
            // Extraer el ID del usuario del token
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(usuarioID, out Guid barberoId))
            {
                await _servicioLocalBarbero.HandleCommand(localBarberoComando, barberoId);
                return Ok();
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Datos")]
        public async Task<IActionResult> ObtenerLocalBarbero()
        {
            // Extraer el ID del usuario del token
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(usuarioID, out Guid barberoId))
            {
                var localBarbero = await _dbContext.LocalBarbero
                    .Where(l => l.BarberoId == barberoId)
                    .Select(l => new
                    {
                        l.Id,
                        l.NombreBarberia,
                        l.Ubicacion,
                        l.NumeroContacto,
                        l.Descripcion,
                        l.Horario,
                        l.Foto,
                        l.BarberoId
                    })
                    .FirstOrDefaultAsync();

                if (localBarbero != null)
                {
                    return Ok(localBarbero);
                }
                else
                {
                    return NotFound("No se encontró un local barbero asociado a este usuario.");

                }
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Datos/{id}")]
        public async Task<IActionResult> ObtenerLocalBarberoPorId(Guid id)
        {
            try
            {
                var localBarbero = await _dbContext.LocalBarbero
                    .FirstOrDefaultAsync(l => l.BarberoId == id);

                if (localBarbero != null)
                {
                    return Ok(localBarbero);
                }
                else
                {
                    return NotFound("No se encontró el local barbero con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("DatosIdLocal/{id}")]
        public async Task<IActionResult> ObtenerLocalBarberoPorIdLocal(Guid id)
        {
            try
            {
                var localBarbero = await _dbContext.LocalBarbero
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (localBarbero != null)
                {
                    return Ok(localBarbero);
                }
                else
                {
                    return NotFound("No se encontró el local barbero con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("TodosLosLocales")]
        public async Task<IActionResult> ObtenerTodosLosLocales()
        {
            try
            {
                var locales = await _dbContext.LocalBarbero
                    .Select(l => new
                    {
                        l.Id,
                        l.NombreBarberia,
                        l.Ubicacion,
                        l.NumeroContacto,
                        l.Descripcion,
                        l.Horario,
                        l.Foto,
                        l.BarberoId
                    })
                    .ToListAsync();

                return Ok(locales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarLocalBarbero/{id}")]
        public async Task<IActionResult> ActualizarLocalBarbero([FromBody] ModificarLocalBarberoComando localBarberoComando)
        {
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(usuarioID, out Guid barberoId))
            {
                await _servicioLocalBarbero.HandleCommand(localBarberoComando);
                return Ok();
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

    }
}
