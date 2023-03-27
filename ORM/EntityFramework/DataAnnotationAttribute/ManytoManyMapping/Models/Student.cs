using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.ManytoManyMapping
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(50, ErrorMessage = "First Name shouldn't be less than 5 chars & not exceed more than 50 chars.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [NotMapped]
        public string FullName { get; set; }

        //Navigation Properties
        public virtual ICollection<Course> Courses { get; set; }
    }
}
