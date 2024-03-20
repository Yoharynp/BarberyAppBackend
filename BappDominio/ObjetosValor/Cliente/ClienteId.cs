using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.Cliente
{
    public record ClienteId
    {
        public Guid Id { get; private init; }

        public ClienteId(Guid id)
        {
            Id = id;
        }

        public static ClienteId Crear(Guid id)
        {
            return new ClienteId(id);
        }
        public static implicit operator Guid(ClienteId id) => id.Id;
    }
}
