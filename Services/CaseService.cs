using CornerstoneCRM.Data.Repositories;
using CornerstoneCRM.Domain;
using CornerstoneCRM.MultiTenancy;

namespace CornerstoneCRM.Services;

public class CaseService : ICaseService
{
    private readonly ICaseRepository _repo;
    private readonly ITenantProvider _tenantProvider;

    public CaseService(ICaseRepository repo, ITenantProvider tenantProvider)
    {
        _repo = repo;
        _tenantProvider = tenantProvider;
    }

    public async Task<IEnumerable<Case>> GetCases()
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        return await _repo.GetCasesAsync(tenantId);
    }

    public async Task<Case?> GetCase(Guid id)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        return await _repo.GetByIdAsync(id, tenantId);
    }

    public async Task<Case> CreateCase(Guid constituentId, string category, string description)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();

        var caseEntity = new Case
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            ConstituentId = constituentId,
            Category = category,
            Description = description,
        };

        await _repo.AddAsync(caseEntity);
        await _repo.SaveChangesAsync();

        return caseEntity;
    }

    public async Task AdvanceCaseStatus(Guid caseId, string newStatus)
    {
        var tenantId = _tenantProvider.GetCurrentTenantId();
        var caseEntity = await _repo.GetByIdAsync(caseId, tenantId);

        if (caseEntity is null) throw new Exception("Case not found");

        caseEntity.AdvanceStatus(newStatus);
        await _repo.SaveChangesAsync();
    }
}
