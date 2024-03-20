using BappDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Servicios
{
    public interface IBarberoServicio
    {
        Task AgregarBarbero(Barbero barbero);
        Task ModificarBarbero(Guid id, Barbero barbero);
        Task <Barbero>EliminarBarbero(Guid id);
    }
}
