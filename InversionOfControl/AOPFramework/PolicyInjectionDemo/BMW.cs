using System;

namespace AOPFramework.PolicyInjectionDemo
{
    public class BMW : ICar
    {
        public BMW()
        {
            Console.WriteLine("==>BMW Initialized<==");
        }

        private string brand = "BMW";
        public string Model { get ; set ; }
        public string Color { get ; set ; }

        public ICar NewObject => this;

        public void GetModelDetails()
        {
            Console.WriteLine($"brand: {brand}\nspeed: 70 KMPH\nmodel: {Model}\ncolor: {Color}");
        }

        public Type GetConcreteDetails()
        {
            return this.GetType();
        }
    }
}
