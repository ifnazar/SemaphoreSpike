using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSpike
{
    class SemaphoreCustom
    {
        private SemaphoreSlim semaphore;

        private ConcurrentQueue<Runnable> queue = new ConcurrentQueue<Runnable>();

        private bool running = false;

        public SemaphoreCustom(int numberOfThreads)
        {
            semaphore = new SemaphoreSlim(numberOfThreads);
            semaphore.Release();
        }

        public void Enqueue(List<Runnable> list)
        {
            foreach (var r in list)
            {
                if (! queue.Contains(r))
                {
                    queue.Enqueue(r);
                } else
                {
                    Console.WriteLine("DUPLICATED:" + r.Name);
                }
            }
            Release();
        }

        private void Release()
        {
            Console.WriteLine("COUNT:" + queue.Count);
            Console.WriteLine("--> " + semaphore.CurrentCount);

            if (running)
                return;

            Task.Run(() =>
            {
                running = true;
                while (queue.Count > 0)
                {
                    Thread.Sleep(100);
                    queue.TryDequeue(out Runnable r);
                    if (r == null)
                        continue;

                    semaphore.Wait();

                    Task.Run(() =>
                    {

                        Console.WriteLine("Task {0} begins in Thread :{1}    name: {2}", Task.CurrentId, Thread.CurrentThread.ManagedThreadId, r.Name);

                        try
                        {
                            r.Run();
                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex.StackTrace);
                        }
                        semaphore.Release();
                        Console.WriteLine("~~~" + r.Name + "    ");
                    });
                }

                running = false;
            });

        }

    }
}
