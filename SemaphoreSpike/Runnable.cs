using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSpike
{
    public class Runnable
    {
        public String Name { get; set; }

        public Runnable(string Name)
        {
            this.Name = Name;
        }

        public void Run()
        {
            Thread.Sleep(1000);
            // CODE TO RUN
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Runnable r = (Runnable)obj;
            return (string.Equals(this.Name, r.Name));
        }

        public override int GetHashCode()
        {
            return (this.Name != null) ? this.Name.GetHashCode() : 0;
        }
    }
}
