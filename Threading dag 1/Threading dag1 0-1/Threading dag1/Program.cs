using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_dag1
{
   
    class Program
    {
        public void WorkThreadFunction()
        {
            Console.WriteLine("Name of thread: " + Thread.CurrentThread.Name);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Simple Thread");
            }
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            Thread thread1 = new Thread(new ThreadStart(prog.WorkThreadFunction));
            thread1.Name = "thread1";
            Thread thread2 = new Thread(new ThreadStart(prog.WorkThreadFunction));
            thread2.Name = "thread2";

            thread1.Start();
            thread2.Start();
            Console.Read();
        }
    }
}
