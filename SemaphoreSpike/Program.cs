using System.Collections.Generic;
using System.Threading;

namespace SemaphoreSpike
{
    class Program
    {
        public static SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(2);

        static void Main(string[] args)
        {
            var nuberOfThreads = 5;
            SemaphoreCustom sc = new SemaphoreCustom(nuberOfThreads);

            while (true)
            {
                List<Runnable> lr = RunnableUtil.LoadList();
                sc.Enqueue(lr);
                Thread.Sleep(3000);
            }
        }

    }

}
