
namespace AOPFramework.Type2_InterfaceInterception
{
    public class DriverHandler
    {
        private readonly ICar _car;
        public DriverHandler(ICar car)
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
