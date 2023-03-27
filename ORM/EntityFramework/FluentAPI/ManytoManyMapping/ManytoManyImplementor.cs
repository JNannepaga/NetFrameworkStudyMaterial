using EntityFramework.FluentAPI.ManytoManyMapping.OrmManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.FluentAPI.ManytoManyMapping
{
    public class ManytoManyImplementor
    {
        public static void Encounter()
        {
            Course c1 = new Course()
            {
                CourseName = "Java"
            };

            Course c2 = new Course()
            {
                CourseName = "C#"
            };

            Student s1 = new Student()
            {
                FirstName = "Fluffy",
                LastName = "Nans",
                Courses = new List<Course>() { c1, c2 }
            };

            Student s2 = new Student()
            {
                FirstName = "Goofy",
                LastName = "Nans",
                Courses = new List<Course>() { c1, c2 }
            };

            using(ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.Students.Add(s1);
                dbContext.Students.Add(s2);

                dbContext.SaveChanges();

                List<Student> students = dbContext.Students.ToList<Student>();

                students.ForEach(s =>
                {
                    Console.WriteLine($"Student Id :{s.StudentId} Name : {s.FullName}");
                });
            }
        }
    }
}
