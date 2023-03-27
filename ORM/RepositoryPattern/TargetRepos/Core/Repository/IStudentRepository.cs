using RepositoryPattern.Models;

namespace RepositoryPattern.TargetRepos.Core
{
    public interface IStudentRepository : IRepository<Student>
    {
        public void GetFailedList();
    }
}
