using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_dag1_3
{
    class Program
    {
        public void RandomTemp()
        {
            Random random = new Random();
            int alarmCount = 0;
            while (true)
            {
                int randTemp = random.Next(-20, 120);
                Console.WriteLine(randTemp);

                if(randTemp >= 101 || randTemp <= -1)
                {
                    Console.WriteLine("Over the allowed interval");
                    alarmCount++;                    
                }
                if (alarmCount > 2)
                {
                    Console.WriteLine("Thread has been terminated due to 3 alarms");
                    Thread.CurrentThread.Abort();
                }
                Thread.Sleep(2000);
            }
        }
        
        static void Main(string[] args)
        {
            Program prog = new Program();
            Thread thread = new Thread(new ThreadStart(prog.RandomTemp));
            thread.Start();
            while (thread.IsAlive)
            {
                Thread.Sleep(10000);
                if (thread.IsAlive == false)
                {
                    Console.WriteLine("Thread is dead");

                }
            }
            Console.Read();
        }
    }
}
