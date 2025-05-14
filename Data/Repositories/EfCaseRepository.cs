using CornerstoneCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneCRM.Data.Repositories;

public class EfCaseRepository : ICaseRepository
{
    private readonly AppDbContext _context;

    public EfCaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Case>> GetCasesAsync(Guid tenantId)
    {
        return await _context.Cases
            .Where(c => c.TenantId == tenantId)
            .OrderByDescending(c => c.UpdatedAt)
            .ToListAsync();
    }

    public async Task<Case?> GetByIdAsync(Guid id, Guid tenantId)
    {
        return await _context.Cases
            .FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);
    }

    public async Task AddAsync(Case caseEntity)
    {
        await _context.Cases.AddAsync(caseEntity);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
