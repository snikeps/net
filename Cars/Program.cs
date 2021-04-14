using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            var query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            var top = 
                cars
                    .OrderByDescending(c => c.Combined)
                    .ThenBy(c => c.Name)
                    .Select(c => c)
                    .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            Console.WriteLine(top.Name);

            foreach(var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }

        }

        private static List<Cars> ProcessFile(string path)
        {
            //return
            //    File.ReadAllLines(path)
            //        .Skip(1)
            //        .Where(line => line.Length > 1)
            //        .Select(Cars.ParseFromCsv)
            //        .ToList();

            //var query =
            //    from line in File.ReadAllLines(path).Skip(1)
            //    where line.Length > 1
            //    select Cars.ParseFromCsv(line);


            var query =
                File.ReadAllLines(path)
                .Skip(1)
                .Where(l => l.Length > 1)
                .ToCar();
                //.Select(l => Cars.ParseFromCsv(l));

            return query.ToList();
        }
    }
}
