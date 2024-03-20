using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBarberyApp
{
    public class Basededatos
    {
        [Fact]
        public void ProbarConexionBaseDatos()
        {
            // Cadena de conexión a la base de datos
            string connectionString = "Server=Yohary\\SQLEXPRESS;Database=BarberyApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False";

            // Intenta establecer una conexión con la base de datos
            using var connection = new SqlConnection(connectionString);
            try
            {
                // Abre la conexión
                connection.Open();

                // Si la conexión se abre sin lanzar una excepción, la prueba pasa
                Assert.True(true);
            }
            catch (SqlException ex)
            {
                // Si se produce una excepción, la prueba falla y se muestra el mensaje de error
                Assert.Fail($"Error al conectar a la base de datos: {ex.Message}");
            }
        }
    }
}
