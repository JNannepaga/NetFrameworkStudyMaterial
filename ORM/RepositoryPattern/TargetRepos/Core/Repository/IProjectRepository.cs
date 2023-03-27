using RepositoryPattern.Models;
using System;

namespace RepositoryPattern.TargetRepos.Core
{
    public interface IProjectRepository : IRepository<Project>
    {
        public void InitiateRework();
    }
}
