
namespace AOPFramework.Type1_TransparentProxy
{
    public class InterceptionImplemention
    {
        public static void Encounter()
        {
            UsingUnityContainer.Client1.Encounter();
            UsingStandaloneContainer.Client1.Encounter();
        }
    }
}
