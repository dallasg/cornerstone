namespace CornerstoneCRM.Domain;

public class Contact
{
    public Guid Id { get; private set; }
    public Guid TenantId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }

    public Contact(Guid tenantId, string firstName, string lastName, string email)
    {
        Id = Guid.NewGuid();
        TenantId = tenantId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public async Task RaiseContactCreatedAsync(Func<Contact, Task> onContactCreated)
    {
        if (onContactCreated is not null)
        {
            await onContactCreated(this);
        }
    }
}
