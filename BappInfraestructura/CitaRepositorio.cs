using BappDominio.Entidades;
using BappDominio.Repositorios;
using BarberyApp.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BappInfraestructura
{
    public class CitaRepositorio : ICitaRepositorio
    {
        private readonly ContextoBarberyApp _context;

        public CitaRepositorio(ContextoBarberyApp context)
        {
            _context = context;
        }

        public async Task AddCitaAsync(Cita cita)
        {
            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCitaAsync(Guid id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cita>> GetAllCitasAsync()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita> GetCitaByIdAsync(Guid id)
        {
            return await _context.Citas.FindAsync(id);
        }

        public async Task UpdateCitaAsync(Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
