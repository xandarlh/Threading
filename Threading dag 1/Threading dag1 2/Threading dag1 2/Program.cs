using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_dag1_2
{
    class Program
    {
        public void WorkThreadFunction(object Object)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Object);
            }
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();

            Thread thread = new Thread(program.WorkThreadFunction);
            thread.Start("C#-trådning er nemt!");

            Thread.Sleep(1000);

            Thread thread1 = new Thread(program.WorkThreadFunction);
            thread1.Start("Også med flere tråde...");
            Console.Read();
        }
    }
}
