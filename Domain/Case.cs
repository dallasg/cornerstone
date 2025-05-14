namespace CornerstoneCRM.Domain;

public class Case
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid ConstituentId { get; set; }

    public string Category { get; set; } = "";
    public string Description { get; set; } = "";

    public string Status { get; set; } = "Open"; // Open, In Progress, Resolved, Closed

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public void AdvanceStatus(string newStatus)
    {
        var allowed = new[] { "Open", "In Progress", "Resolved", "Closed" };

        if (!allowed.Contains(newStatus))
            throw new InvalidOperationException("Invalid status transition");

        Status = newStatus;
        UpdatedAt = DateTime.UtcNow;
    }
}
