using System;

namespace AOPFramework.Type2_InterfaceInterception
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
