using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start();
            Thread.Sleep(400);
        }

        private static void Count()
        {
            for(int i = 0; i < 9; i++)
            {
                Console.WriteLine("Thread 2 executing");
                Thread.Sleep(300);
            }
        }
    }
}
