using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class ProjectEFAdapter : EFAdapter
    {
        private readonly string _connectionString;

        public ProjectEFAdapter(string connectionString)
            : base(connectionString)
        {
            this._connectionString = connectionString;
        }

        public override string ConnectionString => _connectionString;

        public virtual DbSet<Project> Students { get; set; }
    }
}
