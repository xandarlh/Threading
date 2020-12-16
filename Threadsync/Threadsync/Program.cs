using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadsync
{
    //class Program - Opgave 1
    //{
    //    static object _lock = new object();
    //    static int i = 0;
    //    static void AddTwo()
    //    {
    //        while (true)
    //        {
    //            Monitor.Enter(_lock);
    //            i += 2;
    //            Console.WriteLine("'i' has been set to = {1}", Thread.CurrentThread.ManagedThreadId, i);
    //            Thread.Sleep(1000);
    //            Monitor.Exit(_lock);
    //        }
    //    }

    //    static void RemoveOne()
    //    {
    //        while (true)
    //        {
    //            Monitor.Enter(_lock);
    //            i--;
    //            Console.WriteLine("'i' has been set to = {1}", Thread.CurrentThread.ManagedThreadId, i);
    //            Thread.Sleep(1000);
    //            Monitor.Exit(_lock);
    //        }
    //    }

    //    static void Main(string[] args)
    //    {
    //        Thread thread1 = new Thread(AddTwo);
    //        thread1.Start();
    //        Thread thread2 = new Thread(RemoveOne);
    //        thread2.Start();
    //    }
    class Program //Opgave 2 og 3
    {
        static object _lock = new object();
        static int count = 0;
        static void WriteSign(object sign)
        {
            string Sign = sign as string;
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write(Sign);
                        count++;
                    }
                    Console.Write(count + "\n");
                    Thread.Sleep(1000);
                }
            }
        }
        
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(WriteSign);
            thread1.Start("*");
            Thread thread2 = new Thread(WriteSign);
            thread2.Start("#");

        }

    }
}
