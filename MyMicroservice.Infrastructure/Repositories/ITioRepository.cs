using MyMicroservice.Domain.Entities;

namespace MyMicroservice.Infrastructure.Repositories;
public interface ITioRepository
    {
        Task<IEnumerable<Tio>> GetAllAsync();
        Task<Tio?> GetByIdAsync(Guid id);  // Usar Guid aquí
        Task CreateAsync(Tio tio);
        Task UpdateAsync(Tio tio);
        Task DeleteAsync(Guid id);  // Usar Guid aquí
    }
