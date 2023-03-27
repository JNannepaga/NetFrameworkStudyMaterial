using AOPFramework.InterceptionDemo;
using System.Security.Principal;
using System.Threading;


namespace AOPFramework.StandloneInterception
{
    public class Client1
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            ICar interceptedBMW = StandaloneAOPFactory.RegisterAndResolve<ICar, BMW>();
            DriverHandler driver = new DriverHandler(interceptedBMW, new AuditService());
            driver.Invoke();
        }
    }
}
