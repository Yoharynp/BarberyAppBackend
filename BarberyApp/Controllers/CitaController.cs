using BarberyApp.Comandos.CitaComando;
using Microsoft.AspNetCore.Mvc;
using BarberyApp.ServiciosAplicacion;
using BarberyApp.Infraestructura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace BarberyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ServicioCita _citaServicio;
        private readonly IAutorizacionServicio _autorizacionServicio;
        private readonly ContextoBarberyApp _dbContext;

        public CitaController(ServicioCita citaServicio, ContextoBarberyApp dbContext, IAutorizacionServicio autorizacionServicio)
        {
            _citaServicio = citaServicio;
            _dbContext = dbContext;
            _autorizacionServicio = autorizacionServicio;
        }

        [HttpPost]
        [Route("CrearCita")]
        public async Task<IActionResult> CrearCita([FromBody] CrearCitaComando comando)
        {
            try
            {
                var citaId = await _citaServicio.HandleAsync(comando);
                return Ok(citaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la cita: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerCitas")]
        public async Task<IActionResult> ObtenerCitas()
        {
            try
            {
                var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (Guid.TryParse(usuarioID, out Guid clienteId))
                {
                    var citas = await _dbContext.Citas.Where(c => c.ClienteId == clienteId).ToListAsync();
                    if (citas.Any())
                    {
                        return Ok(citas);
                    }
                    else
                    {
                        return NotFound("No se encontraron citas.");
                    }
                }
                else
                {
                    return BadRequest("El identificador de usuario no es válido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las citas: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("ObtenerTodasCitas")]
        public async Task<IActionResult> ObtenerTodasCitas()
        {
            try
            {
                var citas = await _dbContext.Citas.ToListAsync();
                if (citas.Any())
                {
                    return Ok(citas);
                }
                else
                {
                    return NotFound("No se encontraron citas.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las citas: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerCitaBarbero")]
        public async Task<IActionResult> ObtenerCitaenbarbero()
        {
            try
            {
                var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (Guid.TryParse(usuarioID, out Guid barberoId))
                {
                    var localBarbero = await _dbContext.LocalBarbero.FirstOrDefaultAsync(lb => lb.BarberoId == barberoId);
                    if (localBarbero != null)
                    {
                        var citas = await _dbContext.Citas.Where(c => c.LocalBarberoId == localBarbero.Id).ToListAsync();
                        if (citas.Any())
                        {
                            return Ok(citas);
                        }
                        else
                        {
                            return NotFound("No se encontraron citas para este barbero.");
                        }
                    }
                    else
                    {
                        return NotFound("No se encontró el local del barbero.");
                    }
                }
                else
                {
                    return BadRequest("El identificador de usuario no es válido");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las citas del barbero: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerCitaPorId/{id}")]
        public async Task<IActionResult> ObtenerCitaPorId(Guid id)
        {
            try
            {
                var cita = await _dbContext.Citas
                    .Where(c => c.LocalBarberoId == id)
                    .Select(c => new
                    {
                        c.Id,

                    }).ToListAsync();
                if (cita.Any())
                {
                    return Ok(cita);
                }
                else
                {
                    return NotFound("No se encontró la cita.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener la cita: {ex.Message}");
            }
        }



        [Authorize]
        [HttpPut]
        [Route("ToggleCitaEstado/{id}")]
        public async Task<IActionResult> ToggleCitaEstado(Guid id)
        {
            try
            {
                var cita = await _dbContext.Citas.FirstOrDefaultAsync(c => c.Id == id);
                if (cita != null)
                {
                    // Cambiar el estado de la cita
                    cita.Estado = cita.Estado == "Confirmada" ? "Pendiente" : "Confirmada";
                    await _dbContext.SaveChangesAsync();
                    return Ok("Estado de la cita cambiado exitosamente");
                }
                else
                {
                    return NotFound("No se encontró la cita.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado de la cita: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("EliminarCita/{id}")]
        public async Task<IActionResult> EliminarCita(Guid id)
        {
            try
            {
                var cita = await _dbContext.Citas.FirstOrDefaultAsync(c => c.Id == id);
                if (cita != null)
                {
                    _dbContext.Citas.Remove(cita);
                    await _dbContext.SaveChangesAsync();
                    return Ok("Cita eliminada exitosamente");
                }
                else
                {
                    return NotFound("No se encontró la cita.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar la cita: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarCita/{id}")]
        public async Task<IActionResult> ActualizarCita(Guid id, [FromBody] ModificarCitacomando comando)
        {
            try
            {
                var cita = await _dbContext.Citas.FirstOrDefaultAsync(c => c.Id == id);
                if (cita != null)
                {
                    cita.FechaHora = comando.FechaHora;
                    cita.Comentarios = comando.Comentarios;
                    cita.FechaActualizacion = DateTime.Now;
                    await _dbContext.SaveChangesAsync();
                    return Ok("Cita actualizada exitosamente");
                }
                else
                {
                    return NotFound("No se encontró la cita.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la cita: {ex.Message}");
            }
        }


    }
}
