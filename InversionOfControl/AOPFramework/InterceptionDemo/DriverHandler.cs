using AOPFramework.UnityContainerInterception;
using System;

namespace AOPFramework.InterceptionDemo
{
    public class DriverHandler
    {
        private readonly ICar _car;
        private readonly IAuditService _auditService;
        public DriverHandler(ICar car, IAuditService auditService)
        {
            _car = car;
            _auditService = auditService;
        }

        public void Invoke()
        {
            ICar car = _car.NewObject;
            car.Model = "i5 Gen Vo";
            car.Color = "Red";
            car.GetModelDetails();
            Console.WriteLine($"DriverName: {_auditService.GetEmployeeDetails()}");
            Console.WriteLine($"{_car.Model} nd {_car.Color}");
        }
    }
}
