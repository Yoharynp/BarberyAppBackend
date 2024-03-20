using BarberyApp.Comandos.CitaComando;
using BarberyApp.Infraestructura;
using BappDominio.Entidades;
using BappDominio.Repositorios;
using Microsoft.EntityFrameworkCore;


namespace BarberyApp.ServiciosAplicacion
{
    public class ServicioCita
    {
        private readonly ICitaRepositorio _citaRepositorio;
        private readonly ContextoBarberyApp _contexto;

        public ServicioCita(ICitaRepositorio citaRepositorio, ContextoBarberyApp contexto)
        {
            _citaRepositorio = citaRepositorio;
            _contexto = contexto;
        }

        public async Task<Guid> HandleAsync(CrearCitaComando comando)
        {
            var cita = new Cita
            {
                Id = comando.Id,
                LocalBarberoId = comando.IdBarbero,
                ClienteId = comando.IdCliente,
                FechaHora = comando.Fecha,
                Comentarios = comando.Comentario,
                Estado = comando.Estado ? "Confirmada" : "Pendiente" // Establece el estado de la cita
            };

            await _citaRepositorio.AddCitaAsync(cita);

            return cita.Id;
        }

        public async Task ToggleEstadoAsync(string citaId)
        {
            // Buscar la cita en la base de datos
            var cita = await _contexto.Citas.FindAsync(Guid.Parse(citaId));
            if (cita == null)
            {
                throw new Exception("No se encontró la cita");
            }

            // Cambiar el estado de la cita
            cita.Estado = cita.Estado == "Confirmada" ? "Pendiente" : "Confirmada";

            // Guardar los cambios en la base de datos
            await _contexto.SaveChangesAsync();
        }

    }
}
