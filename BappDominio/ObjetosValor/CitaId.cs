using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor
{
    public record CitaId
    {
        public Guid Valor { get; init; }
        internal CitaId(Guid valor)
        {
            Valor = valor;
        }

        public static CitaId Crear(Guid valor) => new(valor);

        public static implicit operator Guid(CitaId id) => id.Valor;
    }
}
