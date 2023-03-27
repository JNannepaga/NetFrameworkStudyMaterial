using System;

namespace AOPFramework.InterceptionDemo
{
    public class AuditService : IAuditService
    {
        public AuditService()
        {
            Console.WriteLine("==>AuditService Initialized<==");
        }
        public string GetEmployeeDetails()
        {
            return "Emp1";
        }
    }
}
