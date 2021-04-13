using System;
using ClassLibrary1;

namespace testcase
{
    class Program
    {
        static void Main(string[] args)
        {
            var circle = Class1.SCircle(1);
            Console.WriteLine(circle);

            var triangle = Class1.STriangle(3, -4, 5);
            Console.WriteLine(triangle);
        }


    }
}
