using System.Collections.Generic;

namespace IdentityOwinIntegrationWithoutEF.SQLAdapter
{

    public interface ISqlAdapter
    {
        Dictionary<string, SqlConnection> sqlConnections { get; }

        SqlConnection ReadConnectionConfig(string configKey);

        IEnumerable<TResult> Select<TResult>(string query, params object[] sqlParams);

        TResult SelectSingle<TResult>(string query, params object[] sqlParams);

        IEnumerable<TResult> Execute<TResult>(string spName, params object[] sqlParams);

    }
}
