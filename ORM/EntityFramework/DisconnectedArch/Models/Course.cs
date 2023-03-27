using System;
using System.Collections.Generic;

namespace EntityFramework.DisconnectedArch
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
