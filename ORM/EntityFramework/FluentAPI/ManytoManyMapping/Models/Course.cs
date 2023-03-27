using System;
using System.Collections.Generic;

namespace EntityFramework.FluentAPI.ManytoManyMapping
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Code { get; set; }

        //Navigational Properties
        public virtual ICollection<Student> Students { get; set; }
    }
}
