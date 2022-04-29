using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var persist = new Persist();

            Console.WriteLine(Persist.Persistence(39));
        }

    }

    public static class Persist
    {
        public static int Persistence(long n)
        {
            int res = 0;
            long multi = n;
            int length = n.ToString().Length;

            while (multi > 10)
            {
                multi = 1;
                for (int i = 0; i < length; i++)
                {
                    multi = multi * (n % 10);
                    n = n / 10;
                }
                res++;
            }

            return res;
        }
    }
}
