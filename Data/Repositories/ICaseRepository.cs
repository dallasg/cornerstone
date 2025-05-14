using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Data.Repositories;

public interface ICaseRepository
{
    Task<IEnumerable<Case>> GetCasesAsync(Guid tenantId);
    Task<Case?> GetByIdAsync(Guid id, Guid tenantId);
    Task AddAsync(Case caseEntity);
    Task SaveChangesAsync();
}
