using CornerstoneCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneCRM.Data.Repositories;

public class EfConstituentRepository : IConstituentRepository
{
    private readonly AppDbContext _context;

    public EfConstituentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Constituent>> SearchAsync(Guid tenantId, string query)
    {
        return await _context.Constituents
            .Where(c => c.TenantId == tenantId && c.Name.Contains(query))
            .ToListAsync();
    }

    public async Task<Constituent?> GetByIdAsync(Guid id, Guid tenantId)
    {
        return await _context.Constituents
            .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);
    }

    public async Task AddAsync(Constituent constituent)
    {
        await _context.Constituents.AddAsync(constituent);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
