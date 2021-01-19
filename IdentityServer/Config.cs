using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api_is4", "My Identity Server")
                {
                    Scopes = {new Scope(IdentityServerConfig.Instance.SCOPE) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = IdentityServerConfig.Instance.CLIENT_ID,
                    RequireClientSecret = true,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret(IdentityServerConfig.Instance.CLIENT_SECRET.Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConfig.Instance.SCOPE,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                    RefreshTokenExpiration = TokenExpiration.Absolute,
                    AbsoluteRefreshTokenLifetime = 3600
                }
            };
        }
    }
}
