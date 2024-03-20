using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record NumeroLocal
    {
        public string Value { get; private set; }
        public NumeroLocal(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("El número de local no puede ser nulo");
            }
            if (value.Length < 3)
            {
                throw new ArgumentOutOfRangeException("El número de local no puede tener menos de 3 caracteres");
            }
            if (value.Length > 11)
            {
                throw new ArgumentOutOfRangeException("El número de local no puede tener más de 5 caracteres");
            }
            this.Value = value;
        }

        public static NumeroLocal Crear(string value)
        {
            return new NumeroLocal(value);
        }

        public static implicit operator string(NumeroLocal value) => value.Value;

        public override string ToString()
        {
            return Value;
        }
    }

}
