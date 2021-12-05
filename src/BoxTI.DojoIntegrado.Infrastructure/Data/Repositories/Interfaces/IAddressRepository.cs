using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces
{
    public interface IAddressRepository : IDisposable
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        Task UpdateAsync(Address address);
        Task RemoveAsync(int id);
    }
}
