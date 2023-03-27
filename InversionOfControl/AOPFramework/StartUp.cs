using NotifyChange = AOPFramework.INotifyChange;
using RealProxyMyApp = AOPFramework.RealProxy.CustomerServiceMyArch;
using RealProxyPractEx = AOPFramework.RealProxy.CustomerServiceRepoPattern;
using UnityContainerInterception = AOPFramework.UnityContainerInterception;
using StandaloneInterception = AOPFramework.StandloneInterception;
using Type1_TransparentProxy = AOPFramework.Type1_TransparentProxy;
using Type2_TransparentProxy = AOPFramework.Type2_InterfaceInterception;
using Type3_VirtualMethodInterception = AOPFramework.Type3_VirtualMethodInterception;
using PolicyInjection = AOPFramework.PolicyInjectionDemo;
using CustomInterceptors = AOPFramework.CustomInterceptors;

namespace AOPFramework
{
    public class StartUp
    {
        public static void Run()
        {
            //PolicyInjection.InterceptionImplemention.Encounter();
            //Type3_VirtualMethodInterception.InterceptionImplemention.Encounter();
            //Type2_TransparentProxy.InterceptionImplemention.Encounter();
            //Type1_TransparentProxy.InterceptionImplemention.Encounter();
            //StandaloneInterception.StandaloneInterceptionImplementor.Encounter();
            //UnityContainerInterception.InterceptionImplemention.Encounter();
            //NotifyChange.Client.Encounter();
            //RealProxyMyApp.DecoratorImplementor.Encounter();
            //RealProxyPractEx.DecoratorImplementor.Encounter();
            //RealProxyMyApp.DynamicProxyImplementor.Encounter();
            //RealProxyPractEx.DynamicProxyImplementor.Encounter();
            CustomInterceptors.Client.Encounter();
        }
    }
}
