using AOPFramework.Type1_TransparentProxy.UsingUnityContainer;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.Type2_InterfaceInterception.UsingStandaloneContainer
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });


            ICar interceptedBMW = StandaloneAOPFactory.RegisterAndResolve<ICar, BMW>();
            DriverHandler driver = new DriverHandler(interceptedBMW);
            driver.Invoke();
        }
    }
}
