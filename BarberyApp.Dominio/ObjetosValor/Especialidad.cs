using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberyApp.Dominio.ObjetosValor
{
    public record Especialidad
    {
        public string Valor { get; set; }

        public Especialidad(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new ArgumentNullException("La especialidad no puede estar vacía");
            }
            this.Valor = valor;
        }
        public override string ToString()
        {
            return Valor;
        }
        public static Especialidad Crear(string valor) => new(valor);

        public static implicit operator string(Especialidad especialidad) => especialidad.Valor;

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }
    }
}
