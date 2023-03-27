
namespace AOPFramework.StandloneInterception
{
    class StandaloneInterceptionImplementor
    {
        public static void Encounter()
        {
            Client1.Encounter();
            Client2.Encounter();
        }
    }
}
