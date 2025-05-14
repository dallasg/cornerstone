using CornerstoneCRM.Domain;

namespace CornerstoneCRM.Services;

public interface IConstituentService
{
    Task<IEnumerable<Constituent>> SearchConstituents(string query);
    Task<Constituent?> GetConstituent(Guid id);
    Task<Constituent> RegisterConstituent(string type, string name, string email, string phone, string address);
}
