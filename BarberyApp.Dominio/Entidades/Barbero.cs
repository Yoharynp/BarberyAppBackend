using BarberyApp.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Entidades
{
    public class Barbero
    {
        public Guid Id { get; init; }
        public Nombre Nombre { get; private set; } 
        public Especialidad Especialidad { get; private init; }

        public Barbero(Guid id)
        {
            this.Id = id;
        }
        public void AsignarNombre(Nombre nombre)
        {
            Nombre = nombre;
        }
    }
}
