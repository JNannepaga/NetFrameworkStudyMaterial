using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    public class ParentChildTasks
    {
        #region Using Task Static Methods
        public static void Type1()
        {
            Task t1 = Task.Factory.StartNew(()=> {

                string personName = FetchData();
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Collect FileDetails");
                    GenerateFile(personName);
                }, TaskCreationOptions.AttachedToParent);

            });

            Task error = t1.ContinueWith((Task1Error) => {
                Console.WriteLine(Task1Error.Exception.Message);
            }, TaskContinuationOptions.OnlyOnFaulted);

            t1.Wait();
        }
        #endregion

        #region Using Task
        public static void Type2()
        {
            string personName = null;
            Task t1 = Task.Factory.StartNew(() => 
            {
                personName = FetchData();
            });

            Task t2 = t1.ContinueWith((Task1)=> { 
                GenerateFile(personName);
                Console.WriteLine(Task1.Exception.Message);
            });

            Task error = t1.ContinueWith((Task1Error) => {
                Console.WriteLine(Task1Error.Exception.Message);
            }, TaskContinuationOptions.OnlyOnFaulted);

            t2.Wait();
        }
        #endregion

        #region Private Methods
        private static string FetchData()
        {
            int a = 5, b = 0;
            int c = a / b;
            Console.WriteLine("Fetching records from DB...");
            Thread.Sleep(2000);
            Console.WriteLine("Records fetched from DB...");
            return "SubhaPranks";
        }

        private static void GenerateFile(string name)
        {
            Console.WriteLine("Creating File...");
            Thread.Sleep(2000);
            Console.WriteLine("File Generated for {0}",name);
        }
        #endregion
    }
}
