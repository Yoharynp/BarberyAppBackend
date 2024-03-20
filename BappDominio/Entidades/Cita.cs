using BappDominio.ObjetosValor;
using BappDominio.ObjetosValor.Barbero;
using BappDominio.ObjetosValor.Cliente;
using BappDominio.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BappDominio.Entidades
{
    public class Cita
    {
        public Guid Id { get; set; }
        public Guid LocalBarberoId { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
