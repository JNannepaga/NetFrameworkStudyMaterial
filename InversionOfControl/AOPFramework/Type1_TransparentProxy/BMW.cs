using System;

namespace AOPFramework.Type1_TransparentProxy
{
    public class BMW : MarshalByRefObject
    {
        public BMW()
        {
            Console.WriteLine("==>BMW Initialized<==");
        }

        private string brand = "BMW";
        public string Model { get ; set ; }
        public string Color { get ; set ; }
        
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
