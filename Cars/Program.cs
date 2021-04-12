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

            var query = cars.Take(40);

            foreach(var car in query)
            {
                Console.WriteLine(car.Name);
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

            var query =
                from line in File.ReadAllLines(path).Skip(1)
                where line.Length > 1
                select Cars.ParseFromCsv(line);

            return query.ToList();
        }
    }
}
