
using System;

namespace AOPFramework.Type3_VirtualMethodInterception
{
    public class Car
    {
        public virtual string Model { get; set; }
        public virtual string Color { get; set; }
        public virtual void GetModelDetails() 
        {
            Console.WriteLine("I'm base method I dont have model");   
        }
        public virtual Type GetConcreteDetails() 
        {
            Console.WriteLine("I'm base method I dont have model");
            return default(Type);
        }
    }
}
