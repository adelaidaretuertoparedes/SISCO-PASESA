namespace SICO.Infrastructure.CrossCutting.Security
{
    public interface IUserIdentity
    {
        string GetCurrentUserName();
        string GetRemoteIpAddress();
    }
}
