using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record IDLocal
    {
        public int Id { get; init; }

        public IDLocal(int id)
        {
            Id = id;
        }

        public static implicit operator int(IDLocal idLocal)
        {
            return idLocal.Id;
        }
    }
}
