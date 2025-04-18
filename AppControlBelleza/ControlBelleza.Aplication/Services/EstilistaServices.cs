using System.Collections.Generic;
using System.Threading.Tasks;
using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Services
{
    public interface IEstilistaService
    {
        Task<Estilista> CrearEstilistaAsync(Estilista estilista);
        Task<IEnumerable<Estilista>> ListarEstilistasAsync();
        Task<Estilista> ObtenerEstilistaAsync(int id);
        Task<Estilista> EditarEstilistaAsync(int id, Estilista estilista);
        Task<bool> EliminarEstilistaAsync(int id);
    }

    public class EstilistaService : IEstilistaService
    {
        public Task<Estilista> CrearEstilistaAsync(Estilista estilista)
        {
            return Task.FromResult(new Estilista());
        }

        public Task<IEnumerable<Estilista>> ListarEstilistasAsync()
        {
            return Task.FromResult<IEnumerable<Estilista>>(new List<Estilista>());
        }

        public Task<Estilista> ObtenerEstilistaAsync(int id)
        {
            return Task.FromResult<Estilista>(null);
        }

        public Task<Estilista> EditarEstilistaAsync(int id, Estilista estilista)
        {
            return Task.FromResult<Estilista>(null);
        }

        public Task<bool> EliminarEstilistaAsync(int id)
        {
            return Task.FromResult(true);
        }
    }
}
