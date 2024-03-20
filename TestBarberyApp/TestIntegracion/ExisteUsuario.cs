using Xunit;
using Microsoft.EntityFrameworkCore;
using BarberyApp.Infraestructura;
using BappDominio.Entidades;

namespace TestBarberyApp.TestIntegracion
{
    public class ExisteUsuario
    {
        [Fact]
        public void UsuarioConNombreCarlosExiste()
        {
            // Arrange
            var connectionString = "Server=Yohary\\SQLEXPRESS;Database=BarberyApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            var options = new DbContextOptionsBuilder<ContextoBarberyApp>()
                .UseSqlServer(connectionString)
                .Options;

            // Act
            using var context = new ContextoBarberyApp(options);
            var usuarioCarlos = context.Barberos.FirstOrDefault(b => b.Nombre == "Carlos");

            // Assert
            Assert.NotNull(usuarioCarlos); // Verifica que el usuario con nombre "Carlos" existe en la base de datos
        }
    }
}
