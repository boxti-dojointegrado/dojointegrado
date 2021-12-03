using BoxTI.DojoIntegrado.Domain.Entities;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;

public interface ICompanyRepository : IDisposable
{
    Task<Company> GetByIdAsync(int id);
    Task AddAsync(Company company);
    Task UpdateAsync(Company company);
    Task RemoveAsync(int id);
}