using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using BoxTI.DojoIntegrado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Company> GetByIdAsync(int id)
        => await _context.Companies
        .AsNoTracking()
        .Include(e => e.Organization)
            .ThenInclude(e => e.Address)
        .FirstOrDefaultAsync(e => e.OrganizationId == id);

    public async Task AddAsync(Company company)
    {
        _context.Companies.Add(company);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Company company)
    {
        _context.Companies.Update(company);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var company = await GetByIdAsync(id);

        _context.Companies.Remove(company);

        await _context.SaveChangesAsync();
    }

    public void Dispose() => _context?.Dispose();
}