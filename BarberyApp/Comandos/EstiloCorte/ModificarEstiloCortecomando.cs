namespace BarberyApp.Comandos.EstiloCorte
{
    public record ModificarEstiloCortecomando(Guid Id, string Nombre, string Descripcion, double Precio, List<string> GaleriaFotos, Guid LocalId);

}
