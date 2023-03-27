using RepositoryPattern.Models;
using RepositoryPattern.TargetRepos.Core;

namespace RepositoryPattern.TargetRepos.SqlProviderEF
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IDbAdapter dbAdapter) 
            : base(dbAdapter)
        {
        }

        public void GetFailedList()
        {
            
        }
    }
}
