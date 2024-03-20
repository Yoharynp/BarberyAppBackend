using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record UbicacionLocal
    {
        public string Value { get; private set; }
        public UbicacionLocal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Value = value;
        }

        public static UbicacionLocal Crear(string value)
        {
            return new UbicacionLocal(value);
        }

        public static implicit operator string(UbicacionLocal value)
        {
            return value.Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
