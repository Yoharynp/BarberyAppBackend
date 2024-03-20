using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor
{
    public record Descripcion
    {
        public string Valor { get; init; }
        public Descripcion(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El valor de la descripción no puede ser nulo o vacío");
            }
            Valor = valor;
        }
        public static Descripcion Crear(string valor) => new(valor);
        public static implicit operator string(Descripcion descripcion) => descripcion.Valor;
        public override string ToString()
        {
            return Valor;
        }
        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }
    }
}
