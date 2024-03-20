using BappDominio.ObjetosValor.Barbero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Entidades
{
    public class Localbarbero
    {
        public Guid Id { get; private init; }
        public string NombreBarberia { get; private set; }
        public string Ubicacion { get; private set; }
        public string NumeroContacto { get; private set; }
        public string Descripcion { get; private set; }
        public string Horario { get; private set; }
        public string Foto { get; private set; }
        public Guid BarberoId { get; private set; }
        public Barbero Barbero { get; private set; }

        public Localbarbero(Guid id)
        {
            Id = id;
        }
        public void AsignarNombre(string nombre)
        {
            NombreBarberia = nombre;
        }
        public void AsignarUbicacion(string ubicaicon)
        {
            Ubicacion = ubicaicon;
        }
        public void AsignarTelefono(string numerocontacto)
        {
            NumeroContacto = numerocontacto;
        }
        public void AsignarDescripcion(string descripcion)
        {
            Descripcion = descripcion;
        }
        public void AsignarHorario(string horario)
        {
            Horario = horario;
        }
        public void AsignarFoto(string foto)
        {
            this.Foto = foto;
        }
        public void AsignarBarberoId(Guid barberoId)
        {
            BarberoId = barberoId;
        }
    }
}
