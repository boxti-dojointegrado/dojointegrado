using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;

public interface INgoRepository : IDisposable
{
    Task<IEnumerable<Ngo>> GetAllAsync();
    Task<Ngo> GetByIdAsync(int id);
    Task AddAsync(Ngo ngo);
    Task UpdateAsync(Ngo ngo);
    Task RemoveAsync(int id);
}