using BarberyApp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Servicios
{
    internal interface ICitaServicio
    {
        Task ProgramarCita(Cita cita);
        Task ModificarCita(Guid id, Cita cita);
        Task EliminarCita(Guid id);
    }
}
