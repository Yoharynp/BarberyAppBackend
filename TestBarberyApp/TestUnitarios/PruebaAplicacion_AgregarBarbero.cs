using BappDominio.Entidades;
using BappDominio.Repositorios;
using BarberyApp.Comandos.BarberoComando;
using BarberyApp.ServiciosAplicacion;
using Moq;

namespace TestBarberyApp.TestUnitarios
{
    public class PruebaAplicacion_AgregarBarbero
    {
        [Fact]
        public async Task HandleCommand_AgregarBarbero_DeberiaAgregarBarberoCorrectamente()
        {
            // Arrange
            var barberoRepositorioMock = new Mock<IBarberoRepositorio>();
            var servicioBarbero = new ServicioBarbero(barberoRepositorioMock.Object);
            var comando = new AgregarBarbareocomando( "Juan", "Corte de cabello", "sadasdasd", "asdasdasd");

            // Act
            await servicioBarbero.HandleCommand(comando);

            // Assert
            barberoRepositorioMock.Verify(repo => repo.Agregar(It.IsAny<Barbero>()), Times.Once);
        }
    }
}
