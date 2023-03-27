using System;

namespace AOPFramework.InterceptionDemo
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

        public ICar NewObject
        {
            get
            {
                return this;
            }
        }
        
        public void GetModelDetails()
        {
            Console.WriteLine($"brand: {brand}\nspeed: 70 KMPH\nmodel: {Model}\ncolor: {Color}");
        }

        public void NonInterfaceMethod()
        {
            Console.WriteLine("NonInterfaceMethod is called");
        }

        public Type GetConcreteDetails()
        {
            return this.GetType();
        }
    }
}
