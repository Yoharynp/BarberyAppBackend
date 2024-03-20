using BappDominio.Entidades;
using BarberyApp.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace TestBarberyApp.TestIntegracion
{
    public class ContextoBaseDeDatosTests
    {
        [Fact]
        public void OnModelCreating_DeberiaConfigurarClavesPrimariasCorrectamente()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<ContextoBarberyApp>()
                .UseSqlServer("Server=Yohary\\SQLEXPRESS;database=BarberyApp;Trusted_Connection=True;MultipleActiveResultSets=true");

            var options = optionsBuilder.Options;

            using var contexto = new ContextoBarberyApp(options);

            // Assert
            var model = contexto.Model;
            Assert.True(model.FindEntityType(typeof(Barbero)).FindPrimaryKey().Properties.Count > 0);
        }
    }
}
