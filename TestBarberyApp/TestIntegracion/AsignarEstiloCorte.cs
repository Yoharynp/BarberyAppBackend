//using BappDominio.Entidades;
//using BappDominio.ObjetosValor;
//using BappDominio.ObjetosValor.Barbero;
//using BappDominio.ObjetosValor.Cliente;
//using BarberyApp.Infraestructura;
//using Microsoft.EntityFrameworkCore;
//using System;
//using Xunit;

//namespace TestBarberyApp.TestIntegracion
//{
//    public class AsignarEstiloCorte
//    {
//        [Fact]
//        public void AsignarEstiloCorte_DeberiaRetornarPrecioCorrecto()
//        {
//            // Arrange
//            var cita = new Cita(Guid.NewGuid());
//            cita.(new ClienteNombre("Cliente 1"));
//            cita.AsignarEspecialidad(new Especialidad("Corte de cabello"));
//            cita.AsignarFecha(DateTime.Now);
//            var estiloCorte = new EstiloCorte(Guid.NewGuid());
//            estiloCorte.AsignarNombreEstiloCorte(new NombreCorte("Estilo 1"));
//            estiloCorte.AsignarDescripcion(new Descripcion("Descripción del estilo"));
//            estiloCorte.AsignarPrecio(new Precio(20));

//            // Act
//            cita.AsignarEstiloCorte(estiloCorte);

//            // Assert
//            Assert.Equal(cita.EstiloCorte, estiloCorte);
//        }
//    }
//}
