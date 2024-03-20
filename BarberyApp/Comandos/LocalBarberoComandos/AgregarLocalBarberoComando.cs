namespace BarberyApp.Comandos.LocalBarberoComandos
{
    public class AgregarLocalBarberoComando
    {
        public Guid LocalBarberoId { get; private set; }
        public string NombreBarberia { get; private set; }
        public string Ubicacion { get; private set; }
        public string NumeroContacto { get; private set; }
        public string Descripcion { get; private set; }
        public string Horario { get; private set; }
        public string Foto { get; private set; }

        public AgregarLocalBarberoComando(string NombreBarberia, string Ubicacion, string NumeroContacto, string Descripcion, string Horario, string foto)
        {
            LocalBarberoId = Guid.NewGuid();
            this.NombreBarberia = NombreBarberia;
            this.Ubicacion = Ubicacion;
            this.NumeroContacto = NumeroContacto;
            this.Descripcion = Descripcion;
            this.Horario = Horario;
            Foto = foto;
        }
    }

}
