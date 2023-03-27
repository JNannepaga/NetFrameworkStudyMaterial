using RepositoryPattern.TargetRepos.Core;
using RepositoryPattern.TargetRepos.SqlProviderEF;
using System;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class RepositoryFactory
    {
        private readonly IDbAdapter _schoolDbAdapter;
        private readonly IDbAdapter _HrDbAdapter;
        public RepositoryFactory()
        {

        }

        public SchoolDbContext SchoolDbContext
        {
            get
            {
                return new SchoolDbContext();
            }
        }

        public ProjectDbContext ProjectDbContext
        {
            get
            {
                return new ProjectDbContext();
            }
        }
    }
}
