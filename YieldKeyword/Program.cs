using System;
using System.Collections;
using System.Collections.Generic;

namespace YieldKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            Car car = new Car("Ford Mustang", "black", 2000);
            cars.Add(car);

            foreach(var enumerator in cars)
            {
                Console.WriteLine($"Car name is {enumerator.label}, color {enumerator.color} and wieght {enumerator.weight}(kg)");
            }
        }
    }
}
