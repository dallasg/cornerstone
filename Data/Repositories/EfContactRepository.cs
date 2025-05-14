using CornerstoneCRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CornerstoneCRM.Data.Repositories;

public class EfContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public EfContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Contact?> GetByIdAsync(Guid id, Guid tenantId) =>
        await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id && c.TenantId == tenantId);

    public async Task<IEnumerable<Contact>> SearchAsync(string query, Guid tenantId) =>
        await _context.Contacts
            .Where(c => c.TenantId == tenantId &&
                        (c.FirstName.Contains(query) || c.LastName.Contains(query)))
            .ToListAsync();

    public async Task AddAsync(Contact contact) =>
        await _context.Contacts.AddAsync(contact);

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
