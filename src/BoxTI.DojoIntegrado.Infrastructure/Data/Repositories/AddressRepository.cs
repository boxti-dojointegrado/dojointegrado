using BoxTI.DojoIntegrado.Domain.Entities;
using BoxTI.DojoIntegrado.Infrastructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoxTI.DojoIntegrado.Infrastructure.Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;
    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Address>> GetAllAsync() => await _context.Addresses.ToListAsync();

    public async Task<Address> GetByIdAsync(int id)
        => await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

    public async Task AddAsync(Address address)
    {
        _context.Addresses.Add(address);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Address address)
    {
        _context.Addresses.Update(address);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var address = await GetByIdAsync(id);

        _context.Addresses.Remove(address);

        await _context.SaveChangesAsync();
    }

    public void Dispose() => _context?.Dispose();
}