using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClassesLayer.Entities;


namespace ServiceLayer
{
    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee employee);

        IAsyncEnumerable<Employee> GetAllEmployeesAsync();

        Task<int> DeleteEmployeeAsync(int employeeId);
    }
}
