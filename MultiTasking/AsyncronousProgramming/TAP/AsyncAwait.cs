using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    public class AsyncAwait1
    {
        public static void Usage1()
        {
            Task<string> getCustomerName = FetchRecordsUsage1();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Normal work.");
            }
            getCustomerName.Wait();
            Console.WriteLine($"retirved records for: {getCustomerName.Result}");
        }

        public static void Usage2()
        {
            FetchRecordsUsage2();
            //string getCustomerName = FetchRecords();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Normal work.");
            }
            //getCustomerName.Wait();
            //Console.WriteLine($"retirved records for: {getCustomerName}");
        }

        public static void Usage3()
        {
            Task<string> getCustomerName = FetchRecordsUsage3();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine($"Normal work.");
            }
            getCustomerName.Wait();
            Console.WriteLine($"retirved records for: {getCustomerName.Result}");
        }

        public static void Usage4_MultiCalls()
        {
            Task<string> getCustomerName = FetchRecordsUsage4_Call1();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine($"Normal work.");
            }
            string name = getCustomerName.GetAwaiter().GetResult();
            Console.WriteLine($"retirved records for: {name}");
        }

        public static async Task<string> FetchRecordsUsage1()
        {
            string customerName = null;
            
            Console.WriteLine("Fetching records from DB...");
            Thread.Sleep(100);
            Console.WriteLine("Records fetched from DB...");
            customerName = "SubhaPranks";
            return customerName;
        }

        public static async void FetchRecordsUsage2()
        {
            string customerName = null;
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching records from DB...");
                Thread.Sleep(100);
                Console.WriteLine("Records fetched from DB...");
                customerName = "SubhaPranks";
            });
            //return customerName;
        }

        public static async Task<string> FetchRecordsUsage3()
        {
            string customerName = null;
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching records from DB...");
                Thread.Sleep(10);
                Console.WriteLine("Records fetched from DB...");
                customerName = "SubhaPranks";
            });
            return customerName;
        }

        public static async Task<string> FetchRecordsUsage4_Call1()
        {
            Console.WriteLine("Before Call 1");
            string name = await FetchRecordsUsage4_Call2();
            Console.WriteLine("After Call 1");
            return name;
        }

        public static async Task<string> FetchRecordsUsage4_Call2()
        {
            Console.WriteLine("Before Call 2");
            string name = await FetchRecordsUsage4_Call3();
            Console.WriteLine("After Call 2");
            return name;
        }

        public static async Task<string> FetchRecordsUsage4_Call3()
        {
            Console.WriteLine("Before Call 3");
            string customerName = null;
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Fetching records from DB...");
                Thread.Sleep(100);
                Console.WriteLine("Records fetched from DB...");
                customerName = "SubhaPranks";
            });
            Console.WriteLine("After Call 3");
            return customerName;
        }
    }
}
