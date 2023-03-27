
namespace IdentityOwinIntegrationWithoutEF.SQLAdapter
{
    public class SqlConnection
    {
        
        private string _configKey = string.Empty;

        public SqlConnection(string configKey)
        {
            _configKey = configKey;
        }

        public string ConfigKey { 
            get 
            {
                return _configKey;
            } 
        }

        public string ServerName { get; set; }
        public string DataBaseName { get; set; }
        public string ClientUserName { get; set; }
        public string ClientPassword { get; set; }
    }
}
