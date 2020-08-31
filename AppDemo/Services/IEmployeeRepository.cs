using AppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDemo.Services
{
    public interface IEmployeeRepository
    {
        Task<string> Add(EmployeeModel employee);
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(string empId);
        Task<int> Update(EmployeeModel employee);
        Task<int> Delete(string empId);
    }
}
