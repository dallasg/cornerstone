namespace CornerstoneCRM.Auth;

public interface IUserContext
{
    Guid GetCurrentUserId();
}
