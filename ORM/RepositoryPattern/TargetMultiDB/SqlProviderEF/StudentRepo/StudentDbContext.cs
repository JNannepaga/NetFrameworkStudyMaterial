using RepositoryPattern.Models;
using RepositoryPattern.TargetMultiDB.Core;
using System;
using System.Data.Entity;

namespace RepositoryPattern.TargetMultiDB.SqlProviderEF
{
    internal sealed class StudentDbContext : IUnitOfWork<IStudentRepository, Student>
    {
        private readonly IDbAdapter _dbAdapter;
        private readonly IStudentRepository _studentRepository;

        public StudentDbContext()
            :this(null, null)
        {

        }
        public StudentDbContext(IDbAdapter dbAdapter, IStudentRepository studentRepository)
        {
            _dbAdapter = dbAdapter ?? new StudentEFAdapter();
            _studentRepository = studentRepository ?? new StudentRepository(_dbAdapter);            
        }

        public IStudentRepository Repository => _studentRepository;

        public void Dispose()
        {
            _dbAdapter.Dispose();
        }

        public void SaveChanges()
        {
            (_dbAdapter as EFAdapter).SaveChanges();
        }

        public void Update(Student entity)
        {
            (_dbAdapter as EFAdapter).Entry<Student>(entity).State = EntityState.Modified;
        }
    }
}
