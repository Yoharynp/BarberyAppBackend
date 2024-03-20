using System;

namespace BarberyApp.Comandos.CitaComando
{
    public record CrearCitaComando
    {
        public Guid Id { get; private set; }
        public Guid IdBarbero { get; private set; }
        public Guid IdCliente { get; private set; }
        public DateTime Fecha { get; private set; }
        public string Comentario { get; private set; }
        public bool Estado { get; private set; }

        public CrearCitaComando(Guid idBarbero, Guid idCliente, DateTime fecha, string comentario, bool estado)
        {
            Id = Guid.NewGuid();
            IdBarbero = idBarbero;
            IdCliente = idCliente;
            Fecha = fecha;
            Comentario = comentario;
            Estado = estado;
        }
    }
}
