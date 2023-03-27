using System;

namespace AOPFramework.Type3_VirtualMethodInterception
{
    public class BMW : Car
    {
        public BMW()
        {
            Console.WriteLine("==>BMW Initialized<==");
        }

        private string brand = "BMW";
        public override string Model { get ; set ; }
        public override string Color { get ; set ; }
        
        public override void GetModelDetails()
        {
            Console.WriteLine($"brand: {brand}\nspeed: 70 KMPH\nmodel: {Model}\ncolor: {Color}");
        }

        public override Type GetConcreteDetails()
        {
            return this.GetType();
        }
    }
}
