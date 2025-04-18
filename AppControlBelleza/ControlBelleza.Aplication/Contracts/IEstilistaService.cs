using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Contracts
{
    public interface IEstilistaService
    {
        Task<Estilista> CreateAsync(Estilista model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Estilista>> GetAllAsync();
        Task<Estilista?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Estilista model);
    }
}
