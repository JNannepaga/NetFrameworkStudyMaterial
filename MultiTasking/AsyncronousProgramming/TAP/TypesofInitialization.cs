using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    public class TypesofInitialization
    {
        #region Type1 :: Using static Task Methods ie, Factory & Run
        public static void Type1()
        {
            Task task1 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine("====Hello world===");
            });

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Normal work");
            }
            task1.Wait();
        } 

        public static void Type1RtnType()
        {
            Task<string> task1 = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(200);
                Console.WriteLine("Done with TASK");
                return "====Hello world===";
            });

            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Normal work");
            }
            task1.Wait();
            Console.WriteLine(task1.Result);
        }

        public static void Type1SepFunc()
        {
            try
            {
                Task<string> task1 = Task.Factory.StartNew(() => Greet("a"));

                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine($"Normal work");
                }
                task1.Wait();
                Console.WriteLine(task1.Result);
            }
            catch(Exception myEx)
            {
                Console.WriteLine($"I'm handled baby");
            }
            
        }

        public static void Type1Run()
        {
            Task t1 = Task.Run(() => Greet("Joseph"));
            Console.WriteLine(t1.Status);
            t1.Wait();
            Console.WriteLine(t1.Status);
        }
        #endregion

        #region Type2 :: Task Class
        public static void Type2()
        {
            Task t1 = new Task(()=>Greet("Joseph"), TaskCreationOptions.LongRunning);
            Console.WriteLine(t1.Status);
            t1.Start();
            Console.WriteLine(t1.Status);
            t1.Wait();
            Console.WriteLine(t1.Status);
        }

        #endregion

        #region Private Methods
        private static void SimpleGreet()
        {
            Thread.Sleep(200);
            Console.WriteLine("Done with TASK");
        }

        private static string Greet(string name)
        {
            int a = 5, b = 0;
            int c = a / b;
            Thread.Sleep(2000);
            Console.WriteLine("Done with TASK");
            return "====Hello world===";
        }
        #endregion
    }
}
