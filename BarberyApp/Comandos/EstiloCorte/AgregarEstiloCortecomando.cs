namespace BarberyApp.Comandos.EstiloCorte
{
    public record AgregarEstiloCortecomando
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public double Precio { get; private set; }
        public List<string> GaleriaFotos { get; private set; }
        public Guid LocalId { get; init; } 

        public AgregarEstiloCortecomando(string nombre, string descripcion, double precio, List<string> galeriaFotos, Guid localId) 
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            GaleriaFotos = galeriaFotos;
            LocalId = localId;
        }
    }
}
