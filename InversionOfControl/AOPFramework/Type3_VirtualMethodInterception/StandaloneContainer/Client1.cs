using AOPFramework.Type1_TransparentProxy.UsingUnityContainer;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.Type3_VirtualMethodInterception.UsingStandaloneContainer
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });


            Car interceptedBMW = StandaloneAOPFactory.RegisterAndResolve<Car, BMW>();
            DriverHandler driver = new DriverHandler(interceptedBMW);
            driver.Invoke();
        }
    }
}
