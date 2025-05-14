namespace CornerstoneCRM.Auth;

public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        // For MVP, hardcoded UserId or pull from claims
        return Guid.Parse("22222222-2222-2222-2222-222222222222");
    }
}
