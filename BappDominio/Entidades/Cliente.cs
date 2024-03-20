using BappDominio.ObjetosValor.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private init; }
        public ClienteNombre Nombre { get; private set; }
        public ClienteApellido Apellido { get; private set; }
        public ClienteEmail Email { get; private set; }
        public ClienteContraseña Contraseña { get; private set; }


        public Cliente(Guid id)
        {
            this.Id = id;
        }

        public void AsignarNombre(ClienteNombre nombre)
        {
            Nombre = nombre;
        }
        public void AsignarApellido(ClienteApellido apellido)
        {
            Apellido = apellido;
        }
        public void AsignarEmail(ClienteEmail email)
        {
            Email = email;
        }
        public void AsignarContraseña(ClienteContraseña contraseña)
        {
            Contraseña = contraseña;
        }
        
    }
}
