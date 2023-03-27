using RepositoryPattern.Models;
using RepositoryPattern.TargetMultiDB.SqlProviderEF;
using System;

namespace RepositoryPattern.TargetMultiDB
{
    public class TargetMultiDbImplementor
    {
        public static void Encounter()
        {
            using(StudentDbContext dbContext = new StudentDbContext())
            {
                Student student = dbContext.Repository.NewEntity;
                student.FirstName = "Joseph";
                student.LastName = "Nans";
                dbContext.Repository.Add(student);
                dbContext.SaveChanges();

                Console.WriteLine($"Id : {student.StudentId} FullName : {student.FullName}");
            }
        }
    }
}
