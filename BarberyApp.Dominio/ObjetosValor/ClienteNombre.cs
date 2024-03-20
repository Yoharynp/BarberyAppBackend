using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.ObjetosValor
{
    public class ClienteNombre
    {
        public string Valor { get; private set; }

        public ClienteNombre(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            this.Valor = valor;
        }
        public static implicit operator ClienteNombre(string valor)
        {
            return new ClienteNombre(valor);
        }
        public override string ToString()
        {
            return Valor;
        }
    }
}
