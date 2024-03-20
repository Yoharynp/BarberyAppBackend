using BappDominio.ObjetosValor.Barbero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace BappDominio.Entidades
{
    public class Barbero
    {
        public Guid Id { get; private init; }
        public NombreBarbero Nombre { get; private set; }
        public ApellidoBarbero Apellido { get; private set; }
        public EmailBarbero Email { get; private set; }
        public Contraseñabarbero Contraseña { get; private set; }


        public Barbero(Guid id)
        {
            this.Id = id;
        }

        public void AsignarNombre(NombreBarbero nombre)
        {
            Nombre = nombre;
        }
        public void AsignarApellido(ApellidoBarbero apellido)
        {
            Apellido = apellido;
        }
        public void AsignarEmail(EmailBarbero email)
        {
            Email = email;
        }
        public void AsignarContraseña(Contraseñabarbero contraseña)
        {
            Contraseña = contraseña;
        }
         
    }
}
