using EntityFramework.DisconnectedArch.ORM;
using System;
using System.Data.Entity;

namespace EntityFramework.DisconnectedArch
{
    public class DiscImplementor
    {
        public static void Encounter()
        {
            //Entity Graph
            Course c1 = new Course()
            {
                CourseName = "Bava",
            };
            Student s1 = new Student()
            {
                FirstName = "Joe",
                LastName = "Nans",
                Course = c1
            };
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                //Attach
                dbContext.Courses.Attach(c1);
                dbContext.Students.Attach(s1);

                //Define State
                dbContext.Entry(c1).State = EntityState.Added;
                dbContext.Entry(s1).State = EntityState.Added;

                dbContext.SaveChanges();

                Course fetchedCourse = dbContext.Entry(c1).Entity;
                Student fetchedStudent = dbContext.Entry(s1).Entity;

                Console.WriteLine($"StudentId : {fetchedStudent.StudentID} " +
                    $"Name : {fetchedStudent.FullName}" +
                    $" Course : {fetchedCourse.CourseName}");
            }
        }
    }
}
