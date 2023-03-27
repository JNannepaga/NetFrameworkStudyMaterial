using RepositoryPattern.Models;
using RepositoryPattern.TargetRepos.SqlProviderEF;
using System;

namespace RepositoryPattern.TargetRepos
{
    public class TargetReposImplementor
    {
        public static void Encounter()
        {
            using (SchoolDbContext dbContext = new SchoolDbContext())
            {
                Teacher teacher = dbContext.TeachersRepository.NewEntity;
                teacher.FirstName = "Sagaya";
                teacher.LastName = "Rani";

                dbContext.TeachersRepository.Add(teacher);
                dbContext.SaveChanges();
                Console.WriteLine($"{teacher.TeacherId} : {teacher.FullName}");
            }
        }
    }
}
