using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Servicios
{
    public interface ICitaServicio
    {
        Task ProgramarCita(Cita cita);
        Task ModificarCita(Guid id, Cita cita);
        Task CancelarCita(Guid id);
    }
}
