using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.Cliente
{
    public record ClienteNombre
    {
        public string Valor { get; private set; }

        public ClienteNombre(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            Valor = valor;
        }

        public static ClienteNombre Crear(string valor) => new(valor);

        public static implicit operator string(ClienteNombre clienteNombre) => clienteNombre.Valor;
        public override string ToString()
        {
            return Valor;
        }


    }
}
