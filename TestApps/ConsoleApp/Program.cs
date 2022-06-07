using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var output = TestClass.ReactiveStringOutput("asdsa");
            output.Subscribe(x => Console.WriteLine(x));
        }
    }

    public class TestClass
    {

        public static IObservable<string> ReactiveStringOutput(string message)
        {
            return Observable.Return(message);
        }

    }
}