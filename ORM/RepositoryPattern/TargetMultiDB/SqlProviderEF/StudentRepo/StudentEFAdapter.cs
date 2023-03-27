using RepositoryPattern.Models;
using RepositoryPattern.TargetMultiDB.Core;
using System.Data.Entity;

namespace RepositoryPattern.TargetMultiDB.SqlProviderEF
{
    public class StudentEFAdapter : EFAdapter
    {
        private readonly string _connectionString;
        public StudentEFAdapter()
            : this("TargetMultiDB_Student")
        {

        }
        public StudentEFAdapter(string connectionString) 
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Student> students { get; set; }
        public override string ConnectionString => _connectionString;
    }
}
