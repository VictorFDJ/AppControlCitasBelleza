using System.Collections.Generic;
using System.Threading.Tasks;
using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Services
{
    public interface IClienteService
    {
        Task<Cliente> CrearClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ListarClientesAsync();
        Task<Cliente> ObtenerClienteAsync(int id);
        Task<Cliente> EditarClienteAsync(int id, Cliente cliente);
        Task<bool> EliminarClienteAsync(int id);
    }

    public class ClienteService : IClienteService
    {
        public Task<Cliente> CrearClienteAsync(Cliente cliente)
        {
            return Task.FromResult(new Cliente());
        }

        public Task<IEnumerable<Cliente>> ListarClientesAsync()
        {
            return Task.FromResult<IEnumerable<Cliente>>(new List<Cliente>());
        }

        public Task<Cliente> ObtenerClienteAsync(int id)
        {
            return Task.FromResult<Cliente>(null);
        }

        public Task<Cliente> EditarClienteAsync(int id, Cliente cliente)
        {
            return Task.FromResult<Cliente>(null);
        }

        public Task<bool> EliminarClienteAsync(int id)
        {
            return Task.FromResult(true);
        }
    }
}
