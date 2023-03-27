using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncronousProgramming.TAP
{
    public class Cancellations
    {
        public static void Encounter()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task t1 = Task.Factory.StartNew(() => 
            {
                Console.WriteLine("Collect FileDetails");
                Thread.Sleep(4000);
                token.ThrowIfCancellationRequested();
            },token);
            Thread.Sleep(1000);
            tokenSource.Cancel();
            t1.Wait();
        }
        
    }
}
