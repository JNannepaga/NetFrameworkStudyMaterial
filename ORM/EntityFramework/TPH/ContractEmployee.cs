using System;

namespace EntityFramework.TPH
{
    public class ContractEmployee : Employee
    {
        public int HoursWorked { get; set; }
        public double HourlyPay { get; set; }
    }
}
