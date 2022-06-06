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
            var interval = 30;

            var source = Observable.Generate<DateTime, DateTime>(DateTime.Now, 
                                                                 x => x < DateTime.Now.AddMinutes(2), 
                                                                 x => x.AddSeconds(1), 
                                                                 x => x);

            //var comparer = Comparer<int>.Default;
            //Func<int, int, int> minOf = (x, y) => comparer.Compare(x, y) < 0 ? x : y;

            var comparer = Comparer<DateTime>.Default;
            Func<DateTime, DateTime, DateTime> minOf = (last, current) => comparer.Compare(last.AddSeconds(interval), current) > 0 ? last : current;
            var min = source.Scan(minOf).DistinctUntilChanged();

            Func<DateTime, DateTime, DateTime> minOfInterval = (last, current) => last.AddSeconds(interval) > current ? last : current;
            var minInterval = source.Scan(minOfInterval).DistinctUntilChanged();

            (DateTime) intervalCheck((DateTime) last, (DateTime) current) => last.AddSeconds(interval) > current ? last : current;

            //Console.WriteLine($"Comparer: {comparer.Compare(5, 5)}");


            Console.WriteLine("All values:");
            source.Subscribe(x => Console.WriteLine(x));

            Console.WriteLine("Min values:");
            min.Subscribe( x => Console.WriteLine(x));

            Console.WriteLine("Min values using inline:");
            minInterval.Subscribe(x => Console.WriteLine(x));

            var inter = TimeSpan.FromSeconds(interval);

            Console.WriteLine(Convert.ToInt32(inter.TotalSeconds));

        }
    }
}