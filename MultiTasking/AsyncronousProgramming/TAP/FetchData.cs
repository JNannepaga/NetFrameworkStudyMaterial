using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    public class FetchData
    {
        public void BeginProcess()
        {
            Console.WriteLine("Fetching records from DB");
            Thread.Sleep(100);
            Console.WriteLine("Completed fetching records");
        }
    }
}
