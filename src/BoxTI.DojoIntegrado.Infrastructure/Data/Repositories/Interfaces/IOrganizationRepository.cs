using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces
{
    public interface IOrganizationRepository : IDisposable
    {
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> GetByIdAsync(int id);
        Task AddAsync(Organization organization);
        Task UpdateAsync(Organization organization);
        Task RemoveAsync(int id);
    }
}
