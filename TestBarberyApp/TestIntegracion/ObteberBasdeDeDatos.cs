using Xunit;
using Microsoft.EntityFrameworkCore;
using BarberyApp.Infraestructura;

namespace TestBarberyApp.TestIntegracion
{
    public class ObteberBasdeDeDatos
    {
        [Fact]
        public void CanRetrieveDataFromDatabase()
        {
            // Arrange
            var connectionString = "Server=Yohary\\SQLEXPRESS;Database=BarberyApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            var options = new DbContextOptionsBuilder<ContextoBarberyApp>()
                .UseSqlServer(connectionString)
                .Options;

            // Act
            using var context = new ContextoBarberyApp(options);
            var barberos = context.Barberos.ToList();

            // Assert
            Assert.NotNull(barberos); // Verifica que la lista no sea nula
            Assert.Equal(2, barberos.Count); // Asegura que hay dos objetos en la lista
            foreach (var barbero in barberos)
            {
                Assert.NotNull(barbero.Nombre); // Verifica que cada barbero tenga un nombre asignado
                Assert.NotNull(barbero.Apellido); // Verifica que cada barbero tenga un apellido asignado
                Assert.NotNull(barbero.Email); // Verifica que cada barbero tenga un email asignado
                Assert.NotNull(barbero.Contraseña); // Verifica que cada barbero tenga una contraseña asignada
            }
        }
    }
}
