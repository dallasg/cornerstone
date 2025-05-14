using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Data.Repositories;

public interface IContactRepository
{
    Task<Contact?> GetByIdAsync(Guid id, Guid tenantId);
    Task<IEnumerable<Contact>> SearchAsync(string query, Guid tenantId);
    Task AddAsync(Contact contact);
    Task SaveChangesAsync();
}
