using CornerstoneCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneCRM.Data.Repositories;

public interface IInteractionRepository
{
    Task<IEnumerable<Interaction>> GetInteractionsForEntity(Guid relatedEntityId, string relatedEntityType, Guid tenantId);
    Task AddAsync(Interaction interaction);
    Task SaveChangesAsync();
}
public class EfInteractionRepository : IInteractionRepository
{
    private readonly AppDbContext _context;

    public EfInteractionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Interaction>> GetInteractionsForEntity(Guid relatedEntityId, string relatedEntityType, Guid tenantId)
    {
        return await _context.Interactions
            .Where(i => i.RelatedEntityId == relatedEntityId && i.RelatedEntityType == relatedEntityType && i.TenantId == tenantId)
            .OrderByDescending(i => i.Timestamp)
            .ToListAsync();
    }

    public async Task AddAsync(Interaction interaction)
    {
        await _context.Interactions.AddAsync(interaction);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
