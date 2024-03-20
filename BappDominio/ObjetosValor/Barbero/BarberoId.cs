using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.Barbero
{
    public record BarberoId
    {
        public Guid Valor { get; init; }
        internal BarberoId(Guid valor)
        {
            Valor = valor;
        }

        public static BarberoId Crear(Guid valor) => new(valor);


        public static implicit operator Guid(BarberoId id) => id.Valor;

    }
}
