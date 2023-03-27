using RepositoryPattern.TargetRepos.Core;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class ProjectDbContext : ApplicationDbContext
    {
        private readonly IProjectRepository _projectRepository;
        
        public ProjectDbContext()
            : this(new ProjectEFAdapter("TargetSingleRepos_ProjectDb"))
        {
            
        }

        public ProjectDbContext(IDbAdapter dbAdapter)
            :this (dbAdapter,
            new ProjectRepository(dbAdapter))
        {

        }
        
        public ProjectDbContext(IDbAdapter dbAdapter, IProjectRepository projectRepository) 
            : base(dbAdapter)
        {
            _projectRepository = projectRepository;
        }
    }
}
