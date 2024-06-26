﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.ObjetosValor.Barbero
{
    public record NombreBarbero
    {
        public string Valor { get; set; }
        public NombreBarbero(string valor)
        {
            //Validar que el nombre no este vacio o nulo
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("El nombre no puede estar vacío", nameof(valor));
            }
            Valor = valor;
        }

        public static NombreBarbero Crear(string valor) => new(valor);

        //sobreescribir metodo ToString para regresar el valor del nombre
        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(NombreBarbero nombre) => nombre.Valor;

        public override int GetHashCode()
        {
            return Valor.GetHashCode();
        }
    }
}
