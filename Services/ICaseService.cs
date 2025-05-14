using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Services;

public interface ICaseService
{
    Task<IEnumerable<Case>> GetCases();
    Task<Case?> GetCase(Guid id);
    Task<Case> CreateCase(Guid constituentId, string category, string description);
    Task AdvanceCaseStatus(Guid caseId, string newStatus);
}
