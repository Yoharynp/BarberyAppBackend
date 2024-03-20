using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.ObjetoValor
{
    internal record Servicio
    {
        public string valor { get; private set; }

        public Servicio(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentException("El valor no puede ser nulo o vacio");
            }
            this.valor = valor;
        }
        public static implicit operator Servicio(string valor)
        {
            return new Servicio(valor);
        }

        public override string ToString()
        {
            return valor;
        }
    }
}
