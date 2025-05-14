using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Services;

public interface IInteractionService
{
    Task<IEnumerable<Interaction>> GetInteractions(Guid relatedEntityId, string relatedEntityType);
    Task<Interaction> LogInteraction(Guid relatedEntityId, string relatedEntityType, string type, string notes);
}
