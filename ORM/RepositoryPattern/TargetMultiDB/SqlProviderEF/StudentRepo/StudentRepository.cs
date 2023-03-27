using RepositoryPattern.Models;
using RepositoryPattern.TargetMultiDB.Core;
using System;

namespace RepositoryPattern.TargetMultiDB.SqlProviderEF
{
    internal sealed class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly IDbAdapter _dbAdapter;

        public StudentRepository(IDbAdapter dbAdapter)
            : base(dbAdapter)
        {
            _dbAdapter = dbAdapter;
        }

        public void FailedStudent()
        {
            throw new NotImplementedException();
        }
    }
}
