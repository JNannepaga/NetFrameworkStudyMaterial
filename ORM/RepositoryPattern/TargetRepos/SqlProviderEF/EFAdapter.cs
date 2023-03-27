using RepositoryPattern.TargetRepos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public abstract class EFAdapter : DbContext, IDbAdapter
    {
        public EFAdapter(string connectionString)
            : base($"name={connectionString}")
        {

        }

        public abstract string ConnectionString { get; }

        public virtual IEnumerable<TResult> Execute<TResult>(string spName, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TResult> Select<TResult>(string query, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }

        public virtual TResult SelectSingle<TResult>(string query, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }
    }
}
