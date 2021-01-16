using Microsoft.Extensions.Configuration;
using System;

namespace IdentityServer
{
    public class IdentityServerConfig
    {
        private static IdentityServerConfig _instance = null;

        public string CLIENT_ID;
        public string CLIENT_SECRET;
        public string SCOPE;

        private const string DEFAULT_CLIENT_ID = "IDENTITYSERVER:CLIENT_ID";
        private const string DEFAULT_CLIENT_SECRET = "IDENTITYSERVER:CLIENT_SECRET";
        private const string DEFAULT_SCOPE = "IDENTITYSERVER:SCOPE";

        public static IdentityServerConfig Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("IS4 Settings not initialized. Load settings before usage.");

                return _instance;
            }
        }

        private IdentityServerConfig(IConfiguration configuration)
        {
            InitIdentityServerConfiguration(configuration);
        }

        private void InitIdentityServerConfiguration(IConfiguration configuration)
        {
            CLIENT_ID = configuration[DEFAULT_CLIENT_ID] ?? DEFAULT_CLIENT_ID;
            CLIENT_SECRET = configuration[DEFAULT_CLIENT_SECRET] ?? DEFAULT_CLIENT_SECRET;
            SCOPE = configuration[DEFAULT_SCOPE] ?? DEFAULT_SCOPE;
        }

        public static void LoadIS4Settings(IConfiguration configuration)
        {
            _instance = new IdentityServerConfig(configuration);
        }
    }
}
