
namespace AOPFramework.Type1_TransparentProxy
{
    public class DriverHandler
    {
        private readonly BMW _car;
        public DriverHandler(BMW car)
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
