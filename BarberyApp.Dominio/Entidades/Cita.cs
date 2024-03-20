using BarberyApp.Dominio.ObjetosValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Entidades
{
    public class Cita
    {
        public Guid Id { get; init; }
        public DateTime Fecha { get; private init; }
        public ClienteNombre ClienteNombre { get; private set; }
        public Especialidad Especialidad { get; private set; }
        public bool Atendida { get; private set; }

        public Cita(Guid id, DateTime fecha)
        {
            this.Id = id;
            this.Fecha = fecha;
        }
        public void AsignarCliente(ClienteNombre clienteNombre)
        {
            ClienteNombre = clienteNombre;
        }
        public void AsignarEspecialidad(Especialidad especialidad)
        {
            Especialidad = especialidad;
        }

    }
}
