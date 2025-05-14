namespace CornerstoneCRM.MultiTenancy;

public interface ITenantProvider
{
    Guid GetCurrentTenantId();
}
