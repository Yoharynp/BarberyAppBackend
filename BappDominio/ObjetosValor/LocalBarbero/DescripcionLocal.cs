using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record DescripcionLocal
    {
        public string Descripcion { get; init; }

        public DescripcionLocal(string descripcion)
        {
            Descripcion = descripcion;
        }

        public static implicit operator string(DescripcionLocal descripcionLocal)
        {
            return descripcionLocal.Descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public static DescripcionLocal Crear(string descripcion)
        {
            return new DescripcionLocal(descripcion);
        }
    }
}
