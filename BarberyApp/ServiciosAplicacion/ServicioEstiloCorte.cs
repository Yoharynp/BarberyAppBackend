using BappDominio.Repositorios;
using BarberyApp.Comandos.EstiloCorte;

namespace BarberyApp.ServiciosAplicacion
{
    public class ServicioEstiloCorte
    {
        private readonly IEstiloCorteRepositorio _estiloCorteRepositorio;

        public ServicioEstiloCorte(IEstiloCorteRepositorio estiloCorteRepositorio)
        {
            _estiloCorteRepositorio = estiloCorteRepositorio;
        }
        public async Task HandleCommand(AgregarEstiloCortecomando estiloCortecomando,Guid localid)
        {
            var estiloCorte = new EstiloCorte(Guid.NewGuid());
            estiloCorte.AsignarLocalBarberoId(localid);
            estiloCorte.AsignarNombreEstiloCorte(estiloCortecomando.Nombre);
            estiloCorte.AsignarDescripcion(estiloCortecomando.Descripcion);
            estiloCorte.AsignarPrecio(estiloCortecomando.Precio);
            estiloCorte.AsignarGaleriaFotos(estiloCortecomando.GaleriaFotos);
            await _estiloCorteRepositorio.AgregarEstiloCorte(estiloCorte);
        }
        public async Task HandleCommand(ModificarEstiloCortecomando comando)
        {
            var estiloCorte = await _estiloCorteRepositorio.ObtenerPorId(comando.Id) ?? throw new Exception("Estilo de corte no encontrado");
            estiloCorte.AsignarNombreEstiloCorte(comando.Nombre);
            estiloCorte.AsignarDescripcion(comando.Descripcion);
            estiloCorte.AsignarPrecio(comando.Precio);
            estiloCorte.AsignarGaleriaFotos(comando.GaleriaFotos);
            await _estiloCorteRepositorio.ModificarEstiloCorte(estiloCorte.Id, estiloCorte);
        }

        //public async Task HandleCommand(EliminarEstiloCortecomando comando)
        //{
        //    var estiloCorte = await _estiloCorteRepositorio.ObtenerPorId(comando.Id) ?? throw new Exception("Estilo de corte no encontrado");
        //    await _estiloCorteRepositorio.EliminarEstiloCorte(estiloCorte.Id);
        //}
        public async Task<List<EstiloCorte>> ObtenerTodos()
        {
            return await _estiloCorteRepositorio.ObtenerTodos();
        }
    }
}
