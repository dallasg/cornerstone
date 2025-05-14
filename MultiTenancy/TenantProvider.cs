namespace CornerstoneCRM.MultiTenancy;

public class TenantProvider : ITenantProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentTenantId()
    {
        // For MVP, hardcoded TenantId for demo purposes
        return Guid.Parse("11111111-1111-1111-1111-111111111111");
    }
}

// public class TenantProvider : ITenantProvider
// {
//     private readonly IHttpContextAccessor _httpContextAccessor;

//     public TenantProvider(IHttpContextAccessor httpContextAccessor)
//     {
//         _httpContextAccessor = httpContextAccessor;
//     }

//     public Guid GetCurrentTenantId()
//     {
//         var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id");
//         if (tenantClaim is null)
//             throw new UnauthorizedAccessException("Tenant not found in token");

//         return Guid.Parse(tenantClaim.Value);
//     }
// }
