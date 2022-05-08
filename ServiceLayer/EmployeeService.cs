using DataAccessLayer;
using DomainClassesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        private bool _isDisposed;
        public ApplicationDbContext _Dbcontext { get; }
        public EmployeeService(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

       

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _Dbcontext.employees.AddAsync(employee);
            await _Dbcontext.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(int employeeId)
        {
            var employee=await _Dbcontext.employees.FindAsync(employeeId);
            if(employee==null)
            {
                return 0;
            }
            _Dbcontext.employees.Remove(employee);
            return await _Dbcontext.SaveChangesAsync();
        }

        public IAsyncEnumerable<Employee> GetAllEmployeesAsync()
        {
            return _Dbcontext.employees.AsAsyncEnumerable();
        }


        private void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_isDisposed)
            {
                try
                {
                    if(disposing)
                    {
                        _Dbcontext.Dispose();
                    }
                }
                finally
                {
                    _isDisposed = true;
                }
            }
        }
    }
}
