using ControlBelleza.Domain.Entities;

namespace ControlBelleza.Application.Contracts
{
    public interface ICitasService
    {
        Task<Citas> CreateAsync(Citas model);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Citas>> GetAllAsync();
        Task<Citas?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Citas model);
    }
}
