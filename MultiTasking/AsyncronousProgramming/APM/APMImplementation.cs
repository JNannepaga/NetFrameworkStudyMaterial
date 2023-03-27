using System;

namespace AsyncronousProgramming.APM
{
    public class APMImplementation
    {
        public static void Encounter()
        {
            FetchData fetchData = new FetchData();
            fetchData.BeginProcess();
            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Normal work---- {fetchData.IsCompleted}");
            }
            fetchData.EndProcess();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("End work----");
            }
        }
    }
}
