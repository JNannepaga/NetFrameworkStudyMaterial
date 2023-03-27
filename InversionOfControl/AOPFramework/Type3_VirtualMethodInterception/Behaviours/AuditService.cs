using System;

namespace AOPFramework.Type3_VirtualMethodInterception
{
    public class AuditService
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
