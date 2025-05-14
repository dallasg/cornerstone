using CornerstoneCRM.Data.Repositories;
using CornerstoneCRM.Domain;
using CornerstoneCRM.MultiTenancy;

namespace CornerstoneCRM.Services;

public class ContactService
{
    private readonly IContactRepository _repo;
    private readonly ITenantProvider _tenantProvider;
    private readonly Func<Contact, Task> _onContactCreated;

    public ContactService(IContactRepository repo, ITenantProvider tenantProvider, Func<Contact, Task> onContactCreated)
    {
        _repo = repo;
        _tenantProvider = tenantProvider;
        _onContactCreated = onContactCreated;
    }

    public async Task<Contact> CreateContact(string firstName, string lastName, string email)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        var contact = new Contact(tenantId, firstName, lastName, email);

        await contact.RaiseContactCreatedAsync(_onContactCreated);

        await _repo.AddAsync(contact);
        await _repo.SaveChangesAsync();

        return contact;
    }

    public Task<Contact?> GetContact(Guid id) =>
        _repo.GetByIdAsync(id, _tenantProvider.GetCurrentTenantId());

    public Task<IEnumerable<Contact>> SearchContacts(string query) =>
        _repo.SearchAsync(query, _tenantProvider.GetCurrentTenantId());
}
