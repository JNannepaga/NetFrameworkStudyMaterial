using RepositoryPattern.Models;
using System.Collections.Generic;

namespace RepositoryPattern.TargetMultiDB.Core
{
    public interface ITeacherRepository
        : IRepository<Teacher>
    {
        public ICollection<Teacher> GetHighPaidTeachers();
    }
}
