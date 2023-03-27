using System;

namespace AOPFramework.CustomInterceptors
{
    public class Client
    {
        public static void Encounter()
        {
            Func<string, string> func = new ServiceHandler().Print;
            LoggingInterceptor loggingInterceptor = new LoggingInterceptor();

            string x = (string)loggingInterceptor.Execute<string, string>(func, "Joe");
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
