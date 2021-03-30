using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id =1,Name="Mary",Department="hr",Email="a@v.com"},
                new Employee() { Id = 2, Name = "Max", Department = "it", Email = "s@a.com" },
                new Employee() { Id = 3, Name = "Sam", Department = "it", Email = "v@z.com" }
            };
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
