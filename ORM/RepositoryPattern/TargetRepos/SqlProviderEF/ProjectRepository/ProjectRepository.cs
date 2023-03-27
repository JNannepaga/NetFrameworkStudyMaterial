using RepositoryPattern.Models;
using RepositoryPattern.TargetRepos.Core;
using System;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(IDbAdapter dbAdapter) 
            : base(dbAdapter)
        {
        }

        public void InitiateRework()
        {
            throw new NotImplementedException();
        }
    }
}
