namespace CornerstoneCRM.Domain;

public class Interaction
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }

    public Guid RelatedEntityId { get; set; } // ConstituentId or CaseId
    public string RelatedEntityType { get; set; } = "Constituent"; // or "Case"

    public string Type { get; set; } = "Note"; // Call, Email, Meeting, Note
    public string Notes { get; set; } = "";

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
