using AOPFramework.InterceptionDemo;
using System.Security.Principal;
using System.Threading;


namespace AOPFramework.StandloneInterception
{
    public class Client2
    {
        public static void Encounter()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity("Administrator"),
                new[] { "ADMIN" });

            ICar interceptedSuziki = StandaloneAOPFactory.RegisterAndResolve<ICar,Suziki>();
            DriverHandler driver = new DriverHandler(interceptedSuziki, new AuditService());
            driver.Invoke();
        }
    }
}
