using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = null;

            if (o is null)
            {
                Console.WriteLine("o does not have a value");
            }
            else
            {
                Console.WriteLine($"o is {o}");
            }

            int? x = 10;

            if (x is null)
            {
                Console.WriteLine("x does not have a value");
            }
            else
            {
                Console.WriteLine($"x is {x.Value}");
            }

            // 'null' check comparison
            Console.WriteLine($"'is' constant pattern 'null' check result : { o is null }");
            Console.WriteLine($"object.ReferenceEquals 'null' check result : { object.ReferenceEquals(o, null) }");
            Console.WriteLine($"Equality operator (==) 'null' check result : { o == null }");
        }
    }
}
