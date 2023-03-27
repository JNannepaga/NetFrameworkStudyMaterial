using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.TPH
{
    public abstract class Employee
    {
        #region Properties
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        #endregion
    }
}
