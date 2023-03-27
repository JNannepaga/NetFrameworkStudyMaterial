
namespace AOPFramework.Type3_VirtualMethodInterception
{
    public class DriverHandler
    {
        private readonly Car _car;
        public DriverHandler(Car car)
        {
            _car = car;
        }

        public void Invoke()
        {
            _car.Model = "i5 Gen Vo";
            _car.Color = "Red";
            _car.GetModelDetails();
        }
    }
}
