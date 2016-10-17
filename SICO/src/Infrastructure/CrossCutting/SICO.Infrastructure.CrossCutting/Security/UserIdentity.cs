using Microsoft.AspNetCore.Http;

namespace SICO.Infrastructure.CrossCutting.Security
{
    public class UserIdentity : IUserIdentity
    {        
        private readonly IHttpContextAccessor _contextAccessor;

        public UserIdentity(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetCurrentUserName()
        {
            if (_contextAccessor == null)
            {
                return string.Empty;
            }
            return string.Empty;
            //ClaimsPrincipal

            //Thread.CurrentPrincipal.Identity

            //var userId = IdentityExtensions.FindFirstValue(Thread.CurrentPrincipal.Identity as ClaimsIdentity, "sub");
            ////var userId= IdentityExtensions.GetUserId(Thread.CurrentPrincipal.Identity);
            //return userId;
        }

        public string GetRemoteIpAddress()
        {            
             return _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
