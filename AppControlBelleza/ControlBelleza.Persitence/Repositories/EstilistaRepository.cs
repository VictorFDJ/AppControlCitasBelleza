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
    public interface IEstilistaRepository
    {
        Task<IEnumerable<Estilista>> GetAllAsync();
        Task<Estilista> GetByIdAsync(int id);
        Task<Estilista> AddAsync(Estilista estilista);
        Task<Estilista> UpdateAsync(Estilista estilista);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Estilista>> GetByEspecialidadAsync(string especialidad);
        Task<IEnumerable<Estilista>> SearchByNameAsync(string nombre);
        Task<IEnumerable<Estilista>> GetAvailableByDateAsync(DateTime fecha);
    }

    public class EstilistaRepository 
    {
        private readonly DataContext _context;

        public EstilistaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estilista>> GetAllAsync()
        {
            return await _context.Estilista
                .ToListAsync();
        }

        public async Task<Estilista> GetByIdAsync(int id)
        {
            return await _context.Estilista
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Estilista> AddAsync(Estilista estilista)
        {
            await _context.Estilista.AddAsync(estilista);
            await _context.SaveChangesAsync();
            return estilista;
        }

        public async Task<Estilista> UpdateAsync(Estilista estilista)
        {
            var estilistaExistente = await _context.Estilista.FindAsync(estilista.Id);
            if (estilistaExistente == null)
                return null;

            // Actualizar propiedades
            _context.Entry(estilistaExistente).CurrentValues.SetValues(estilista);
            await _context.SaveChangesAsync();

            return estilistaExistente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var estilista = await _context.Estilista.FindAsync(id);
            if (estilista == null)
                return false;

            _context.Estilista.Remove(estilista);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Estilista.AnyAsync(e => e.Id == id);
        }

      

        public async Task<IEnumerable<Estilista>> SearchByNameAsync(string nombre)
        {
            return await _context.Estilista
                .Where(e => e.Nombre.Contains(nombre) || e.Apellido.Contains(nombre))
                .ToListAsync();
        }

       
    }
}