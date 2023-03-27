using AOPFramework.Type1_TransparentProxy.UsingUnityContainer;
using System.Security.Principal;
using System.Threading;

namespace AOPFramework.Type1_TransparentProxy.UsingStandaloneContainer
{
    class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });


            BMW interceptedBMW = StandaloneAOPFactory.RegisterAndResolve<BMW, BMW>();
            DriverHandler driver = new DriverHandler(interceptedBMW);
            driver.Invoke();
        }
    }
}
