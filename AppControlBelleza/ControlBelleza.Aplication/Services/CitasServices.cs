using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Services.CitasServices
{
    public interface ICitasService
    {
        Task<Citas> CrearCitaAsync(Citas cita);
        Task<IEnumerable<Citas>> ListarCitasAsync();
        Task<Citas> ObtenerCitaAsync(int id);
        Task<Citas> EditarCitaAsync(int id, Citas cita);
        Task<bool> EliminarCitaAsync(int id);
    }

    public class CitasService : ICitasService
    {
        public Task<Citas> CrearCitaAsync(Citas cita)
        {
            return Task.FromResult(new Citas());
        }

        public Task<IEnumerable<Citas>> ListarCitasAsync()
        {
            return Task.FromResult<IEnumerable<Citas>>(new List<Citas>());
        }

        public Task<Citas> ObtenerCitaAsync(int id)
        {
            return Task.FromResult<Citas>(null);
        }

        public Task<Citas> EditarCitaAsync(int id, Citas cita)
        {
            return Task.FromResult<Citas>(null);
        }

        public Task<bool> EliminarCitaAsync(int id)
        {
            return Task.FromResult(true);
        }
    }
}
