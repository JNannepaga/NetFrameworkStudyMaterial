using RepositoryPattern.Models;

namespace RepositoryPattern.TargetMultiDB.Core
{
    public interface IStudentRepository
       : IRepository<Student>
    {
        public void FailedStudent();
    }
}
