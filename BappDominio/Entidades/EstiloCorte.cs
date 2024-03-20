using BappDominio.Entidades;

public class EstiloCorte
{
    public Guid Id { get; private init; }
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }
    public List<string> GaleriaFotos { get; private set; }
    public double Precio { get; private set; }
    public Guid LocalId { get; private set; }
    public Localbarbero LocalBarbero { get; private set; }

    public EstiloCorte(Guid id)
    {
        Id = id;
    }
    public void AsignarNombreEstiloCorte(string nombreEstiloCorte)
    {
        Nombre = nombreEstiloCorte;
    }
    public void AsignarDescripcion(string descripcion)
    {
        Descripcion = descripcion;
    }
    public void AsignarGaleriaFotos(List<string> galeriaFotos)
    {
        GaleriaFotos = galeriaFotos;
    }
    public void AsignarPrecio(double precio)
    {
        Precio = precio;
    }
    public void AsignarLocalBarberoId(Guid localbarberoId)
    {
        LocalId = localbarberoId;
    }
}
