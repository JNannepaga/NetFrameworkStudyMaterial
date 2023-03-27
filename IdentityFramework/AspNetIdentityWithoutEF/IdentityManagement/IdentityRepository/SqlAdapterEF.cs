using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using IdentityOwinIntegrationWithoutEF.Models;
using IdentityOwinIntegrationWithoutEF.SQLAdapter;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class SqlAdapterEF : DbContext, ISqlAdapter
    {
        private readonly SqlConnection _sqlConnection = null;
        public SqlAdapterEF(string ConfigKey)
            : base($"name = {ConfigKey}")
        {
            _sqlConnection = sqlConnections[ConfigKey];
            Database.SetInitializer<SqlAdapterEF>(new DropCreateDatabaseIfModelChanges<SqlAdapterEF>());
        }

        #region SqlAdapter
        public Dictionary<string, SqlConnection> sqlConnections { 
            get 
            {
                return new Dictionary<string, SqlConnection>()
                {
                    { "IdentityManagement", ReadConnectionConfig("IdentityManagement")}
                };
            } 
        }

        public SqlConnection ReadConnectionConfig(string configKey)
        {
            return new SqlConnection(configKey)
            {
                ClientUserName = "NA",
                ClientPassword = "NA",
                DataBaseName = "IdentityManagement",
                ServerName = ""
            };
        }
        #endregion

        #region EntityFramework ModelBindings
        public Action<DbModelBuilder> SpBinder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SpBinder?.Invoke(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region DataSet
        public DbSet<Models.MyUser> Users { get; set; }
        public DbSet<Models.MyRole> Roles { get; set; }
        public DbSet<Models.MyUserLogins> MyUserLogins { get; set; }
        #endregion

        #region SP Implementations
        public IEnumerable<TResult> Select<TResult>(string query, params object[] sqlParams)
        {
            return this.Database.SqlQuery<TResult>(query, sqlParams).ToList<TResult>();
        }

        public TResult SelectSingle<TResult>(string query, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TResult> Execute<TResult>(string spName, params object[] sqlParams)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}