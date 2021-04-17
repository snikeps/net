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
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");

            // query syntax

            var query =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)
                } into result
                orderby result.Max descending
                select result;

            // extension method syntax

            var query2 =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                    (m, g) =>
                        new
                        {
                            Manufacturer = m,
                            Cars = g
                        })
                .GroupBy(m => m.Manufacturer.Headquarters);


            foreach (var result in query)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\tMax = {result.Max}");
                Console.WriteLine($"\tMin = {result.Min}");
                Console.WriteLine($"\tAvg = {result.Avg}");
            }
           

        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
        }

        private static List<Cars> ProcessCars(string path)
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
