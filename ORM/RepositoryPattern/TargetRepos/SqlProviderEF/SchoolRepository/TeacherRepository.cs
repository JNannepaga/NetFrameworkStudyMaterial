using RepositoryPattern.Models;
using RepositoryPattern.TargetRepos.Core;
using System;
using System.Collections.Generic;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class TeacherRepository : Repository<Teacher>, ITeachersRepository
    {
        public TeacherRepository(IDbAdapter dbAdapter) 
            : base(dbAdapter)
        {
        }

        public void GetHighestPaid()
        {
            throw new NotImplementedException();
        }
    }
}
