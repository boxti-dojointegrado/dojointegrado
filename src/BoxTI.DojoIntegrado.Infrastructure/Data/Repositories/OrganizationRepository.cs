using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly INgoRepository _ngoRepository;
        private readonly ICompanyRepository _companyRepository;

        public OrganizationRepository(
            ApplicationDbContext context,
            INgoRepository ngoRepository,
            ICompanyRepository companyRepository    
        )
        {
            _context = context;
            _ngoRepository = ngoRepository;
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
            => await _context.Organizations.AsNoTracking().ToListAsync();

        public async Task<Organization> GetByIdAsync(int id)
            => await _context.Organizations
                .AsNoTracking()
                .Include(e => e.Address)
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task AddAsync(Organization organization)
        {
            _context.Organizations.Add(organization);

            if (organization.IsCompany)
                await _companyRepository.AddAsync(new Company { OrganizationId = organization.Id });
            else
                await _ngoRepository.AddAsync(new Ngo { OrganizationId = organization.Id });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Organization organization)
        {
            _context.Organizations.Update(organization);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var organization = await GetByIdAsync(id);

            _context.Organizations.Remove(organization);

            await _context.SaveChangesAsync();
        }

        public void Dispose() => _context?.Dispose();
    }
}
