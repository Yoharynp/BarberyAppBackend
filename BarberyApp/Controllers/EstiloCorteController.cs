using BappDominio.Entidades;
using BappDominio.ObjetosValor;
using BarberyApp.Comandos.EstiloCorte;
using BarberyApp.Infraestructura;
using BarberyApp.ServiciosAplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BarberyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstiloCorteController : ControllerBase
    {
        private readonly ServicioEstiloCorte _servicioEstiloCorte;
        private readonly ContextoBarberyApp _dbContext;

        public EstiloCorteController(ServicioEstiloCorte servicioEstiloCorte, ContextoBarberyApp dbContext)
        {
            _servicioEstiloCorte = servicioEstiloCorte;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AgregarEstiloCorte([FromBody] AgregarEstiloCortecomando estiloCorteComando)
        {
            // Extraer el ID del usuario del token
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(usuarioID, out Guid barberoId))
            {
                // Buscar el LocalBarbero asociado al Barbero
                var localBarbero = await _dbContext.LocalBarbero.FirstOrDefaultAsync(lb => lb.BarberoId == barberoId);

                if (localBarbero != null)
                {
                    // Llamar al servicio para agregar el estilo de corte al LocalBarbero
                    await _servicioEstiloCorte.HandleCommand(estiloCorteComando, localBarbero.Id); // Pasar localBarbero.Id
                    return Ok();
                }
                else
                {
                    return BadRequest("No se encontró un LocalBarbero asociado al Barbero.");
                }
            }
            else
            {
                return BadRequest("El identificador de usuario no es válido");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> ObtenerEstilosCorte()
        {
            // Extraer el ID del usuario del token
            var usuarioID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(usuarioID, out Guid localid))
            {
                // Buscar el localbarbero asociado al usuario
                var localbarbero = await _dbContext.LocalBarbero.FirstOrDefaultAsync(lb => lb.BarberoId == localid);

                if (localbarbero != null)
                {
                    // Obtener el ID del localbarbero
                    var localbarberoid = localbarbero.Id;

                    // Consultar los estilos de corte asociados al localbarbero
                    var estilosCorte = await _dbContext.EstiloCorte
                        .Where(e => e.LocalId == localbarberoid)
                        .Select(e => new
                        {
                            e.Nombre,
                            e.Descripcion,
                            e.Precio,
                            e.GaleriaFotos
                        })
                        .ToListAsync();

                    if (estilosCorte == null || !estilosCorte.Any())
                    {
                        return NotFound("No se encontraron estilos de corte");
                    }
                    else
                    {
                        return Ok(estilosCorte);
                    }
                }
                else
                {
                    return NotFound("No se encontró un localbarbero asociado al usuario");
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
                var localBarbero = await _dbContext.EstiloCorte
                    .FirstOrDefaultAsync(l => l.LocalId == id);

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
        [Route("Lista/{id}")]
        public async Task<IActionResult> ObtenerEstilosCorte(Guid id)
        {
            try
            {
                // Consultar los estilos de corte asociados al local barbero con el ID proporcionado
                var estilosCorte = await _dbContext.EstiloCorte
                    .Where(e => e.LocalId == id)
                    .Select(e => new
                    {

                        e.Nombre,
                        e.Descripcion,
                        e.Precio,
                        e.GaleriaFotos
                    })
                    .ToListAsync();

                if (estilosCorte == null || !estilosCorte.Any())
                {
                    return NotFound("No se encontraron estilos de corte asociados al local barbero con el ID proporcionado");
                }
                else
                {
                    return Ok(estilosCorte);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("ObtenerLocalPorId/{id}")]
        public async Task<IActionResult> ObtenerEstilosCorteById(Guid id)
        {
            try
            {
                // Consultar los estilos de corte asociados al local barbero con el ID proporcionado
                var estilosCorte = await _dbContext.EstiloCorte
                    .Where(e => e.LocalId == id)
                    .Select(e => new
                    {

                        e.Id,
                    })
                    .ToListAsync();

                if (estilosCorte == null || !estilosCorte.Any())
                {
                    return NotFound("No se encontraron estilos de corte asociados al local barbero con el ID proporcionado");
                }
                else
                {
                    return Ok(estilosCorte);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ObtenerTodosEstilosCorte")]
        public async Task<IActionResult> ObtenerTodosCliente()
        {
            var clientes = await _servicioEstiloCorte.ObtenerTodos();
            return Ok(clientes);
        }

        [Authorize]
        [HttpPut]
        [Route("ActualizarEstiloCorte/{id}")]
        public async Task<IActionResult> ActualizarEstiloCorte([FromBody] ModificarEstiloCortecomando modificarEstiloCortecomando)
        {
            try
            {
                await _servicioEstiloCorte.HandleCommand(modificarEstiloCortecomando);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("EliminarEstiloCorte/{id}")]
        public async Task<IActionResult> EliminarEstiloCorte(Guid id)
        {
            try
            {
                var estiloCorte = await _dbContext.EstiloCorte.FirstOrDefaultAsync(e => e.Id == id);
                if (estiloCorte != null)
                {
                    _dbContext.EstiloCorte.Remove(estiloCorte);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound("No se encontró el estilo de corte con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("EliminarEstiloCortePorLocal/{id}")]
        public async Task<IActionResult> EliminarEstiloCortePorLocal(Guid id)
        {
            try
            {
                var estilosCorte = await _dbContext.EstiloCorte.Where(e => e.LocalId == id).ToListAsync();
                if (estilosCorte != null && estilosCorte.Any())
                {
                    _dbContext.EstiloCorte.RemoveRange(estilosCorte);
                    await _dbContext.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound("No se encontraron estilos de corte asociados al local barbero con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


    }
}
