using System;
using Microsoft.Owin.Hosting;
using IISHost = OWIN_IISHost;

namespace OWIN_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateSelfWebHostBuilder();
        }

        public static void CreateSelfWebHostBuilder()
        {
            using (WebApp.Start<Startup>("http://localhost:3777"))
            {
                Console.WriteLine("Host is listening to Port: 3777 ");
                Console.ReadKey();
            }
        }

        public static void CreateIISWebHostBuilder()
        {
            using (WebApp.Start<IISHost.Startup>("http://localhost:3777"))
            {
                Console.WriteLine("Host is listening to Port: 3777 ");
                Console.ReadKey();
            }
        }
    }
}
