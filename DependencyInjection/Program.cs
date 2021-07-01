using System;
using System.Collections.Generic;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            List<Employee> ListEmployee = employeeBL.GetAllEmployees();

            foreach (var employee in ListEmployee)
            {
                Console.WriteLine($"ID = {employee.ID}, Name = {employee.Name}, Department = {employee.Department}");
            }
        }
    }
}
