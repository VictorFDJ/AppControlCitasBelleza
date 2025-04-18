using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlBelleza.Domain.Entities;
using ControlBelleza.ControlBelleza.Persitence;

namespace ControlBelleza.Persitence.Repositories
{
    public interface ICitasRepository
    {
        Task<IEnumerable<Citas>> GetAllAsync();
        Task<Citas> GetByIdAsync(int id);
        Task<Citas> AddAsync(Citas cita);
        Task<Citas> UpdateAsync(Citas cita);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Citas>> GetCitasByClienteIdAsync(int clienteId);
        Task<IEnumerable<Citas>> GetCitasByFechaAsync(DateTime fecha);
    }

    public class CitasRepository : ICitasRepository
    {
        private readonly DataContext _context;

        public CitasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Citas>> GetAllAsync()
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .ToListAsync();
        }

        public async Task<Citas> GetByIdAsync(int id)
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Citas> AddAsync(Citas cita)
        {
            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<Citas> UpdateAsync(Citas cita)
        {
            var citaExistente = await _context.Citas.FindAsync(cita.Id);
            if (citaExistente == null)
                return null;

           
            _context.Entry(citaExistente).CurrentValues.SetValues(cita);
            await _context.SaveChangesAsync();

            return citaExistente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Citas.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Citas>> GetCitasByClienteIdAsync(int clienteId)
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .Where(c => c.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Citas>> GetCitasByFechaAsync(DateTime fecha)
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .Where(c => c.FechaCita.Date == fecha.Date)
                .ToListAsync();
        }
    }
}