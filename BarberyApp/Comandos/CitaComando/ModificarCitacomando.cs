namespace BarberyApp.Comandos.CitaComando
{
    public record ModificarCitacomando
    {
        public Guid Id { get; private set; }
        public string Comentarios { get; private set; }
        public DateTime FechaHora { get; private set; }

        public ModificarCitacomando(Guid id, string comentarios, DateTime fechaHora)
        {
            Id = id;
            Comentarios = comentarios;
            FechaHora = fechaHora;
        }

    }

}
