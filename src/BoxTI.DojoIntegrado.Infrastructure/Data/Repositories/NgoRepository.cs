using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using BoxTI.DojoIntegrado.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class NgoRepository : INgoRepository
{
    private readonly ApplicationDbContext _context;
    public NgoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ngo>> GetAllAsync()
        => await _context.Ngos.AsNoTracking().ToListAsync();

    public async Task<Ngo> GetByIdAsync(int id)
        => await _context.Ngos
        .AsNoTracking()
        .Include(e => e.Organization)
            .ThenInclude(e => e.Address)
        .FirstOrDefaultAsync(e => e.OrganizationId == id);

    public async Task AddAsync(Ngo ngo)
    {
        _context.Ngos.Add(ngo);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ngo ngo)
    {
        _context.Ngos.Update(ngo);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var ngo = await GetByIdAsync(id);

        _context.Ngos.Remove(ngo);

        await _context.SaveChangesAsync();
    }

    public void Dispose() => _context?.Dispose();
}