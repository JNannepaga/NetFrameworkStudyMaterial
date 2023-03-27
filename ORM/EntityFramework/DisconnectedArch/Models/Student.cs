using System;

namespace EntityFramework.DisconnectedArch
{
    public class Student
    {
        //Scalar Properties
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get 
            {
                return this.FirstName+" "+this.LastName;
            } 
        }

        public int CourseRefId { get; set; }

        //Navigational Properties
        public virtual Course Course { get; set; }
    }
}
