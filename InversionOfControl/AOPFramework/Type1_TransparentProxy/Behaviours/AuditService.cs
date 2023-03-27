using System;

namespace AOPFramework.Type1_TransparentProxy
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
