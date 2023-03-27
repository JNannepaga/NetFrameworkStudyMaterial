using System;

namespace AOPFramework.RealProxy
{
    class AddUserDetailsHandler
    {
        public void Invoke()
        {
            Console.WriteLine("Registering new user");
        }
    }
}
