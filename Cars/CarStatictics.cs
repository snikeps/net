using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class CarStatictics
    {
        public CarStatictics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        public CarStatictics Accumulate(Cars car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }


        public CarStatictics Compute()
        {
            Average = Total / Count;
            return this;
        }

        public int Total { get; set; }
        public int Count { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public double Average { get; set; }
    }
}
