using System;
using System.Collections.Generic;

namespace RepositoryPattern.TargetMultiDB.Core
{
    public interface IDbAdapter : IDisposable
    {
        public string ConnectionString { get; }
        IEnumerable<TResult> Select<TResult>(string query, params object[] sqlParams);
        TResult SelectSingle<TResult>(string query, params object[] sqlParams);
        IEnumerable<TResult> Execute<TResult>(string spName, params object[] sqlParams);
    }
}
