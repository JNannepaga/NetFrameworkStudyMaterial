using System;
using System.Threading;

namespace AsyncronousProgramming.APM
{
    public class FetchData : IAsyncResult
    {
        private bool _isCompleted = false;
        private ManualResetEvent _waitHandle = new ManualResetEvent(false);
        
        public bool IsCompleted => _isCompleted;

        public WaitHandle AsyncWaitHandle => _waitHandle;

        public object AsyncState => throw new NotImplementedException();

        public bool CompletedSynchronously => throw new NotImplementedException();

        public void BeginProcess()
        {
            _isCompleted = false;
            Thread t1 = new Thread(AsyncOp);
            t1.Start();
        }

        public void EndProcess()
        {
            _waitHandle.WaitOne();
            _isCompleted = true;
        }

        public void AsyncOp()
        {
            Console.WriteLine("Fetching records from DB");
            Thread.Sleep(100);
            Console.WriteLine("Completed fetching records");
            _waitHandle.Set();
            _isCompleted = true;
        }
    }
}
