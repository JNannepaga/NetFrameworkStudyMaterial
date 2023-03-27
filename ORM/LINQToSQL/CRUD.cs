using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQToSQL
{
    public class CRUD
    {
        public static void Encounter()
        {
            while (true)
            {
                Console.WriteLine("Enter your option 1.Add 2.Update 3.Delete 4.Print");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Student student = new Student()
                        {
                            Name = "Chinni Lipun",
                            Gender = 2
                        };
                        AddStudent(student);
                        break;

                    case 2:
                        UpdateStudent();
                        break;

                    case 3:
                        DeleteStudent();
                        break;

                    case 4:
                    default:
                        GetAllStudents();
                        break;
                }
            }
            
        }

        public static void GetAllStudents()
        {
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                IEnumerator<SP_GetAllStudentsResult> students = dbContext.SP_GetAllStudents().GetEnumerator();
                while (students.MoveNext())
                {
                    Console.WriteLine($"Roll Num:{students.Current.StudentId} Name:{students.Current.Name} Gender:{PrintGender(students.Current.Gender)}");
                }
            }
        }

        public static void AddStudent(Student student)
        {
            using(SampleDataContext dbContext = new SampleDataContext())
            {
                student.StudentId = (from stud in dbContext.Students
                                    select stud).Max(s => s.StudentId) + 1;
                dbContext.Students.InsertOnSubmit(student);
                dbContext.SubmitChanges();
            }
        }

        public static void UpdateStudent()
        {
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                Student student = (from stud in dbContext.Students 
                                   orderby stud.StudentId descending
                                   select stud).FirstOrDefault();

                student.Gender = Convert.ToInt16(student.Gender == 1 ? 2 : 1);
                dbContext.SubmitChanges();
            }
        }

        public static void DeleteStudent()
        {
            using (SampleDataContext dbContext = new SampleDataContext())
            {
                var student = (from stud in dbContext.Students
                                   orderby stud.StudentId descending
                                   select stud).FirstOrDefault();
                 
                short studentId = Convert.ToInt16(dbContext.Students.Max(x => x.StudentId));
                
                dbContext.Students.DeleteOnSubmit(student);
                dbContext.SubmitChanges();
                
            }
        }
        public static string PrintGender(short? g) => g == 1 ? "Male" : "Female"; 
            
    }
}
