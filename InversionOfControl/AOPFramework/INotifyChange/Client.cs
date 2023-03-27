using System;
using System.ComponentModel;

namespace AOPFramework.INotifyChange
{
    public class Client
    {
        public static void Encounter()
        {
            Person p1 = new Person()
            {
                PId = 1,
                Name = "Joseph"
            };

            p1.PId = 2;
            Console.ReadKey();
        }

    }
}
