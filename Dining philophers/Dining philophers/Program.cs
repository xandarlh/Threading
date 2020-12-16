using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dining_philophers
{
    class Program
    {
        static bool[] forks = new bool[5] { false, false, false, false, false };

        static void EatIfAvailable(object inputList)
        {
            List<int> list = inputList as List<int>;
            while (true)
            {
                Monitor.Enter(forks);

                if (forks[list[0]] == true || forks[list[1]] == true)
                {
                    Console.WriteLine("{0} waiting", Thread.CurrentThread.Name);
                    Monitor.Wait(forks);
                }

                forks[list[0]] = true;
                forks[list[1]] = true;
                Monitor.Pulse(forks);
                Console.WriteLine("{0} eating", Thread.CurrentThread.Name);
                Thread.Sleep(1500);

                forks[list[0]] = false;
                forks[list[1]] = false;

                Monitor.Exit(forks);              
            }
        }

        static void Main(string[] args)
        {
            Thread philosopher1 = new Thread(EatIfAvailable);
            philosopher1.Name = "Philosopher 1";
            List<int> phil1 = new List<int>() { 0, 1 };
            philosopher1.Start(phil1);

            Thread philosopher2 = new Thread(EatIfAvailable);
            philosopher2.Name = "Philosopher 2";
            List<int> phil2 = new List<int>() { 1, 2 };
            philosopher2.Start(phil2);

            Thread philosopher3 = new Thread(EatIfAvailable);
            philosopher3.Name = "Philosopher 3";
            List<int> phil3 = new List<int>() { 2, 3 };
            philosopher3.Start(phil3);

            Thread philosopher4 = new Thread(EatIfAvailable);
            philosopher4.Name = "Philosopher 4";
            List<int> phil4 = new List<int>() { 3, 4 };
            philosopher4.Start(phil4);

            Thread philosopher5 = new Thread(EatIfAvailable);
            philosopher5.Name = "Philosopher 5";
            List<int> phil5 = new List<int>() { 4, 0 };
            philosopher5.Start(phil5);

        }

        
    }
}
