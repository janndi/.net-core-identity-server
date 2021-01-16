using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myresourceapi", "My Resource API")
                {
                    Scopes = {new Scope(IdentityServerConfig.Instance.SCOPE) }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // for public api
                new Client
                {
                    ClientId = IdentityServerConfig.Instance.CLIENT_ID,
                    RequireClientSecret = true,
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret(IdentityServerConfig.Instance.CLIENT_SECRET.Sha256())
                    },
                    AllowedScopes = { IdentityServerConfig.Instance.SCOPE }
                }
            };
        }
    }
}
