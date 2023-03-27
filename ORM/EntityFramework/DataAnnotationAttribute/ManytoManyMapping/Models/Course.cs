using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.ManytoManyMapping
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [MaxLength(50, ErrorMessage = "Course Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string CourseName { get; set; }

        [MaxLength(50, ErrorMessage = "Course Code shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string Code { get; set; }

        //Navigational Properties
        public virtual ICollection<Student> Students { get; set; }
    }
}
