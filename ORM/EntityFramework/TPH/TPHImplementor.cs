using System;

namespace EntityFramework.TPH
{
    public class TPHImplementor
    {
        public static void Encounter()
        {
            Employee emp1 = new PermanentEmployee()
            {
                EmpId = 1,
                FirstName = "Joseph",
                LastName = "Nans",
                AnnualPay = 1000
            };

            Employee emp2 = new ContractEmployee()
            {
                EmpId = 1,
                FirstName = "Subha",
                LastName = "Swain",
                HourlyPay = 500,
                HoursWorked = 8
            };

            using (ApplicationDBContext dBContext = new ApplicationDBContext())
            {
                dBContext.Employees.Add(emp1);
                dBContext.Employees.Add(emp2);
                dBContext.SaveChanges();

                foreach (Employee emp in dBContext.Employees)
                {
                    if (emp is PermanentEmployee)
                    {
                        PermanentEmployee permtEmp = emp as PermanentEmployee; 
                        Console.WriteLine("I'm permanent Employee");
                        Console.WriteLine($"EmpID: {permtEmp.EmpId} FullName: {permtEmp.FullName} AnnualPay: {permtEmp.AnnualPay}");
                    }
                    else
                    {
                        ContractEmployee cntrctEmp = emp as ContractEmployee;
                        Console.WriteLine("I'm Contract Employee");
                        Console.WriteLine($"EmpID: {cntrctEmp.EmpId} FullName: {cntrctEmp.FullName} Pay: {cntrctEmp.HoursWorked*cntrctEmp.HourlyPay}");
                    }
                }
            }

        }
    }
}
