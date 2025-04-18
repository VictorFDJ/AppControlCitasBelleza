using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Contracts
{
    public interface IClienteService
    {
        Task<Cliente> CreateAsync(Cliente model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Cliente model);
    }
}
