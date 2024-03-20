using Xunit;
using Microsoft.EntityFrameworkCore;
using BarberyApp.Infraestructura;
using BappInfraestructura;
using BappDominio.Entidades;
using BappDominio.ObjetosValor.Barbero;

namespace TestBarberyApp.TestIntegracion
{
    public class AsignacionNombreBarberoTest
    {
        [Fact]
        public void AsignacionNombreBarberoCorrecta()
        {
            // Arrange
            var connectionString = "Server=Yohary\\SQLEXPRESS;Database=BarberyApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";
            var options = new DbContextOptionsBuilder<ContextoBarberyApp>()
                .UseSqlServer(connectionString)
                .Options;

            using var contexto = new ContextoBarberyApp(options);

            // Crea un nuevo objeto Barbero con un nombre específico
            var nuevoBarbero = new Barbero(Guid.NewGuid());
            nuevoBarbero.AsignarNombre(new NombreBarbero("Rodrigo"));
            nuevoBarbero.AsignarEmail(new EmailBarbero("asdas@gmail.com"));
            nuevoBarbero.AsignarContraseña(new Contraseñabarbero("12345678"));
            nuevoBarbero.AsignarApellido(new ApellidoBarbero("Perez"));


            // Act
            contexto.Barberos.Add(nuevoBarbero);
            contexto.SaveChanges();

            // Assert
            var barberoEncontrado = contexto.Barberos.FirstOrDefault(b => b.Nombre == "Rodrigo");
            Assert.NotNull(barberoEncontrado); // Verifica que se haya encontrado un barbero con el nombre "Rodrigo"
        }
    }
}
