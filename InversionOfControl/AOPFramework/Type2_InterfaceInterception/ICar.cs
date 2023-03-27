
using System;

namespace AOPFramework.Type2_InterfaceInterception
{
    public interface ICar
    {

        string Model { get; set; }
        string Color { get; set; }
        ICar NewObject { get; }
        void GetModelDetails();
        Type GetConcreteDetails();
    }
}
