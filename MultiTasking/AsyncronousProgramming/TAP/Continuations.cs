using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    class Continuations
    {
        public static void SimpleContinuation()
        {
            Task<string> anticident = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching Records from DB...");
                Thread.Sleep(2000);
                Console.WriteLine("Records retrived from DB...");
                return "Subha Prankita";
            });

            Task childSuccess = anticident.ContinueWith((ant) =>
            {
                Console.WriteLine("Create File...");
                Thread.Sleep(2000);
                Console.WriteLine("File Generated for {0}",ant.Result);
            }, TaskContinuationOptions.NotOnFaulted);

            Task childError = anticident.ContinueWith((ant) =>
            {
                Console.WriteLine("File Create Cancalled due to : {0}", ant.Exception.Message);
            }, TaskContinuationOptions.OnlyOnFaulted);

            childSuccess.Wait();
        }

        public static void ContinueWhenAny()
        {
            Task<string> anticident1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching Records from DB1...");
                Thread.Sleep(4000);
                Console.WriteLine("Records retrived from DB1...");
                return "Subha";
            });

            Task<string> anticident2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching Records from DB2...");
                Thread.Sleep(2000);
                Console.WriteLine("Records retrived from DB2...");
                return "Prankita";
            });

            Task[] tasks = new Task[] { anticident1, anticident2 };
            Task childSuccess = Task.Factory.ContinueWhenAny(tasks, ants=>
            {
                Console.WriteLine("Create File...");
                Thread.Sleep(100);
                Console.WriteLine("File Generated for {0}");
            }); 
            childSuccess.Wait();
        }

        public static void ContinueWhenAll()
        {
            Task<string> anticident1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching Records from DB1...");
                Thread.Sleep(4000);
                Console.WriteLine("Records retrived from DB1...");
                return "Subha";
            });

            Task<string> anticident2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching Records from DB2...");
                Thread.Sleep(2000);
                Console.WriteLine("Records retrived from DB2...");
                return "Prankita";
            });

            Task[] tasks = new Task[] { anticident1, anticident2 };
            Task childSuccess = Task.Factory.ContinueWhenAll(tasks, ants =>
            {
                Console.WriteLine("Create File...");
                Thread.Sleep(100);
                Console.WriteLine("File Generated for {0}");
            });
            childSuccess.Wait();
        }
    }
}
