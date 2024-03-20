using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;

namespace TestBarberyApp.TestUnitarios
{
    public class AsignarNombre
    {
        [Fact]
        public void AsignarNombre_DeberiaAsignarNombreCorrectamente()
        {
            // Arrange
            var barberoId = Guid.NewGuid(); // Generar un nuevo Guid para el barbero
            var barbero = new Barbero(barberoId); // Crear el barbero con el Guid generado

            // Act
            barbero.AsignarNombre(NombreBarbero.Crear("Juan"));

            // Assert
            Assert.Equal("Juan", barbero.Nombre.ToString());
        }
    }
}
