﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Cars
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }

        public int Combined { get; set; }

        //internal static Cars ParseFromCsv(string line)
        //{
        //    var columns = line.Split(',');

        //    return new Cars
        //    {
        //        Year = int.Parse(columns[0]),
        //        Manufacturer = columns[1],
        //        Name = columns[2],
        //        Displacement = double.Parse(columns[3]),
        //        Cylinders = int.Parse(columns[4]),
        //        City = int.Parse(columns[5]),
        //        Highway = int.Parse(columns[6]),
        //        Combined = int.Parse(columns[7])
        //    };
        //}
                
    }
}
