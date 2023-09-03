using Microsoft.AspNetCore.DataProtection;

namespace auth_reinventing
{
    public class AuthService
    {
        private readonly IDataProtectionProvider idp;
        private readonly IHttpContextAccessor accessor;

        public AuthService(IDataProtectionProvider idp, IHttpContextAccessor accessor)
        {
            this.idp = idp;
            this.accessor = accessor;
        }

        public void SignIn(string username)
        {
            var protector = idp.CreateProtector("auth-cookie");
            accessor.HttpContext?.Response.Headers.Add("set-cookie", $"auth={protector.Protect($"usr:{username}")}");
        }
    }
}
