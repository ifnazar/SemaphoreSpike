using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreSpike
{
    public class RunnableUtil
    {
        public static List<Runnable> LoadList()
        {
            List<Runnable> lr = new List<Runnable>();

            for (long i = 0; i < 10; i++)
            {
                var r = new Runnable("" + i);
                lr.Add(r);

            }
            return lr;
        }
    }
}
