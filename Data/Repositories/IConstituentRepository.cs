using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Data.Repositories;

public interface IConstituentRepository
{
    Task<IEnumerable<Constituent>> SearchAsync(Guid tenantId, string query);
    Task<Constituent?> GetByIdAsync(Guid id, Guid tenantId);
    Task AddAsync(Constituent constituent);
    Task SaveChangesAsync();
}
