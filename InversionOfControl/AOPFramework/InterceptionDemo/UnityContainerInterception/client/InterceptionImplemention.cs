
namespace AOPFramework.UnityContainerInterception
{
    public class InterceptionImplemention
    {
        public static void Encounter()
        {
            Client1.Encounter();
            Client2.Encounter();
        }
    }
}
