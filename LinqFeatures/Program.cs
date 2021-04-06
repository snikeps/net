using System;
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
            Func<int, int> square = x => x * x; // <int, int>  - last parameter defines return type
            Func<int, int, int> add = (x, y) => x + y;

            Console.WriteLine(square(4));
            Console.WriteLine(add(40, 11));

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

            foreach(var employee in developers.Where(
                        e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}
