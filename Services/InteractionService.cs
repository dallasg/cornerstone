using CornerstoneCRM.Data.Repositories;
using CornerstoneCRM.Domain;
using CornerstoneCRM.MultiTenancy;

namespace CornerstoneCRM.Services;

public class InteractionService : IInteractionService
{
    private readonly IInteractionRepository _repo;
    private readonly ITenantProvider _tenantProvider;

    public InteractionService(IInteractionRepository repo, ITenantProvider tenantProvider)
    {
        _repo = repo;
        _tenantProvider = tenantProvider;
    }

    public async Task<IEnumerable<Interaction>> GetInteractions(Guid relatedEntityId, string relatedEntityType)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        return await _repo.GetInteractionsForEntity(relatedEntityId, relatedEntityType, tenantId);
    }

    public async Task<Interaction> LogInteraction(Guid relatedEntityId, string relatedEntityType, string type, string notes)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();

        var interaction = new Interaction
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            RelatedEntityId = relatedEntityId,
            RelatedEntityType = relatedEntityType,
            Type = type,
            Notes = notes,
            Timestamp = DateTime.UtcNow
        };

        await _repo.AddAsync(interaction);
        await _repo.SaveChangesAsync();

        return interaction;
    }
}
