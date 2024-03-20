using BarberyApp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.Servicios
{
    public interface IBarberoServicio
    {
        Task AgregarBarbero(Barbero barbero);
        Task ModificarBarbero(Guid id, Barbero barbero);
        Task EliminarBarbero(Guid id);
    }
}
