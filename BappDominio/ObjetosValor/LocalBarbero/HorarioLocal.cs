using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.LocalBarbero
{
    public record HorarioLocal
    {
        public string Horario { get; private init; }
        public HorarioLocal(string horario)
        {
            Horario = horario;
        }

        public static implicit operator string(HorarioLocal horarioLocal)
        {
            return horarioLocal.Horario;
        }

        public static HorarioLocal Crear(string horario)
        {
            return new HorarioLocal(horario);
        }

        public override string ToString()
        {
            return Horario;
        }
    }
}
