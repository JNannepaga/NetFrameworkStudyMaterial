using RepositoryPattern.Models;
using System;

namespace RepositoryPattern.TargetRepos.Core
{
    public interface ITeachersRepository : IRepository<Teacher>
    {
        public void GetHighestPaid();
    }
}
