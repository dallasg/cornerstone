using CornerstoneCRM.Data.Repositories;
using CornerstoneCRM.Domain;
using CornerstoneCRM.MultiTenancy;

namespace CornerstoneCRM.Services;

public class ConstituentService : IConstituentService
{
    private readonly IConstituentRepository _repo;
    private readonly ITenantProvider _tenantProvider;

    public ConstituentService(IConstituentRepository repo, ITenantProvider tenantProvider)
    {
        _repo = repo;
        _tenantProvider = tenantProvider;
    }

    public async Task<IEnumerable<Constituent>> SearchConstituents(string query)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        return await _repo.SearchAsync(tenantId, query);
    }

    public async Task<Constituent?> GetConstituent(Guid id)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        return await _repo.GetByIdAsync(id, tenantId);
    }

    public async Task<Constituent> RegisterConstituent(string type, string name, string email, string phone, string address)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        var constituent = new Constituent
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Type = type,
            Name = name,
            Email = email,
            Phone = phone,
            Address = address
        };

        await _repo.AddAsync(constituent);
        await _repo.SaveChangesAsync();

        return constituent;
    }
}
