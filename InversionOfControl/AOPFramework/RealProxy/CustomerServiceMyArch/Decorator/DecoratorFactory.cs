using System;

namespace AOPFramework.RealProxy.CustomerServiceMyArch
{
    public class DecoratorFactory<T>
    {
        private readonly T _customerService;
        
        public DecoratorFactory(T customerService)
        {
            _customerService = customerService;
        }

        public T Intercept()
        {
            try
            {
                Console.WriteLine("Logging :: Entered try");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured at {typeof(T)} :\n {ex}");
                
            }
            return default(T);
        }
    }
}
