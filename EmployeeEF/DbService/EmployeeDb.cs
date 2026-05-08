using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmployeeEF.Models;

namespace EmployeeEF.DbService
{
    class EmployeeDb
    {
        public ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            var employeeList = (from emp in AppContext.dbContext.employee
                                orderby emp.Lastname
                                select emp).ToList();

            foreach (var employee in employeeList)
            {
                employees.Add(employee);
            }

            return employees;
        }


        public void AddEmployee(Employee emp)
        {
            try { 
                AppContext.dbContext.employee.Add(emp);
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException("ошибка добавления нового сотрудника " + ex.Message);
            }
        }

        public void DeleteEmployee(Employee emp)
        {
            try
            {
                AppContext.dbContext.Remove(emp);
            }
            catch (DataServiceRequestException ex)
            {
                throw new ApplicationException("ошибка удаления сотрудника " + ex.Message);
            }
        }
    }
}
