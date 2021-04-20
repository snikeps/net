using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();
            //db.Database.Log = Console.WriteLine; // logging

            //var query =
            //    from car in db.Cars
            //    orderby car.Combined descending, car.Name ascending
            //    select car;

            var query =
                db.Cars.Where(c => c.Manufacturer == "BMW")
                        .OrderByDescending(c => c.Combined)
                        .ThenBy(c => c.Name)
                        .Take(10);


            foreach (var car in query)
            {
                Console.WriteLine($"{car.Name} : {car.Combined}");
            }
        }

        private static void InsertData()
        {
            var cars = ProcessCars("fuel.csv");
            var db = new CarDb();
            db.Database.Log = Console.WriteLine; // logging

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static void QueryXml()
        {
            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = XDocument.Load("fuel.xml");

            var query =
                //from element in document.Descendants("Car")  // pulls out all matched elements in any hierarchy level
                //from element in document.Element(ns + "Cars").Elements(ex + "Car")
                from element in document.Element(ns + "Cars")?.Elements(ex + "Car") 
                                                        ?? Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"    // if attribute is optional "?" symbol will be required and program won't fail
                select element.Attribute("Name").Value;

            foreach(var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");


            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = new XDocument();
            var cars = new XElement(ns + "Cars",

                from record in records
                select new XElement(ex + "Car",
                                new XAttribute("Name", record.Name),
                                new XAttribute("Combined", record.Combined),
                                new XAttribute("Manufacturer", record.Manufacturer)
                                ));

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));

            document.Add(cars);
            document.Save("fuel.xml");
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
