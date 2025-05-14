namespace CornerstoneCRM.Auth;

public class JwtUserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtUserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("sub");
        if (userIdClaim is null)
            throw new UnauthorizedAccessException("User ID not found in token");

        return Guid.Parse(userIdClaim.Value);
    }
}
