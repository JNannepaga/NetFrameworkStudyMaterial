using System;

namespace AOPFramework.InterceptionDemo
{
    public class Suziki : ICar
    {
        public Suziki()
        {
            Console.WriteLine("==>Suziki Initialized<==");
        }

        private string brand = "Suziki";
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
            Console.WriteLine($"brand: {brand}\nspeed: 50 KMPH\nmodel: {Model}\ncolor: {Color}");
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
