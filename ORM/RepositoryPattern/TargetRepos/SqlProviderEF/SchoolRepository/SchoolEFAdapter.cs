using RepositoryPattern.Models;
using System;
using System.Data.Entity;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class SchoolEFAdapter : EFAdapter
    {
        private readonly string _connectionString;
        
        public SchoolEFAdapter(string connectionString)
            : base(connectionString)
        {
            this._connectionString = connectionString;
        }

        public override string ConnectionString => _connectionString;

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
