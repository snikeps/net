using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>();
            ListEmployees.Add(new Employee() { ID = 1, Name = "Pranaya", Department = "IT" });
            ListEmployees.Add(new Employee() { ID = 2, Name = "Kumar", Department = "HR" });
            ListEmployees.Add(new Employee() { ID = 3, Name = "Rout", Department = "Payroll" });

            return ListEmployees;
        }
    }
}
