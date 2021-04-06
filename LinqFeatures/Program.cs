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

            Action<int> write = x => Console.WriteLine(x); // only incoming parameters (same as void)
            
            //Console.WriteLine(square(4));
            //Console.WriteLine(add(40, 11));
            //write(square(add(3, 4)));


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

            var query = developers.Where(e => e.Name.Length == 5)
                                   .OrderBy(e => e.Name)
                                   .Select(e => e);

            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name descending
                         select developer;

            foreach(var employee in query2)
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
