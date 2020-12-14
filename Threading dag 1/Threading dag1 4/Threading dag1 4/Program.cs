using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_dag1_4
{
    class Program
    {
        public static char input = '*';
        public void Input()
        {
            while (true)
            {               
                input = Console.ReadKey().KeyChar;             
            }
        }
        public void Print()
        {
            while (true)
            {
                Console.Write(input);
                Thread.Sleep(200);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            Thread input = new Thread(program.Input);
            input.Start();

            Thread print = new Thread(program.Print);
            print.Start();
            Console.Read();
        }
    }
}
