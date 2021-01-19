using IdentityModel;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Raw["username"]))
                return Task.CompletedTask;
            
            context.Result.IsError = false;
            context.Result.Subject = GetClaimsPrincipal(context.Request.Raw["username"]);

            return Task.CompletedTask;
        }

        private static ClaimsPrincipal GetClaimsPrincipal(string username)
        {
            var issued = DateTimeOffset.Now.ToUnixTimeSeconds();

            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, username),
                new Claim(JwtClaimTypes.AuthenticationTime, issued.ToString()),
                new Claim(JwtClaimTypes.IdentityProvider, "localhost")
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims));
        }
    }
}
