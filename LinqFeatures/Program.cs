﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            //Employee[] developers = new Employee[]
            {
                new Employee{Id = 1, Name = "Scott"},
                new Employee{Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>()
            //List<Employee> sales = new List<Employee>()
            {
                new Employee {Id = 3 , Name = "Alex"}
            };

            IEnumerator<Employee> enumerator = sales.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }
    }
}
