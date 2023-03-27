using RepositoryPattern.Models;
using RepositoryPattern.TargetMultiDB.SqlProviderEF;

namespace RepositoryPattern.TargetMultiDB.Core
{
    class RepositoryFactory
    {
        public static IUnitOfWork<IStudentRepository, Student> StudentDbContext => new StudentDbContext();
    }
}
