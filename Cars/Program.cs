﻿using System;
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


            // Join with composit key

            var query =
                from car in cars
                join manufacturer in manufacturers 
                    on new { car.Manufacturer, car.Year } 
                        equals 
                        new { Manufacturer = manufacturer.Name, manufacturer.Year }
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };

            // same query using extension method

            var query2 =
                cars.Join(manufacturers,
                            c => new { c.Manufacturer, c.Year },
                            m => new { Manufacturer = m.Name, m.Year },
                            (c, m) => new
                            {
                                m.Headquarters,
                                c.Name,
                                c.Combined
                            })
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);

            //var result = cars.Any(c => c.Manufacturer == "Ford");

            //var result = cars.Select(c =>  new { c.Manufacturer, c.Name, c.Combined});



            ////// SelectMany example
            //var result = cars.SelectMany(c => c.Name);

            //foreach (var character in result)
            //{
            //    Console.WriteLine(character);
            //}


            //foreach (var car in result.Take(3))
            //{
            //    Console.WriteLine($"{car.Name} : {car.Manufacturer}");
            //}



            ////// example of First
            //var top = 
            //    cars
            //        .OrderByDescending(c => c.Combined)
            //        .ThenBy(c => c.Name)
            //        .Select(c => c)
            //        .First(c => c.Manufacturer == "BMW" && c.Year == 2016);

            //Console.WriteLine(top.Name);

            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
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
