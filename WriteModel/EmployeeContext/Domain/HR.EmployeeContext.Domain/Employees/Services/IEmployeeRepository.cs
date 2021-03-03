using System;
using System.Linq.Expressions;
using HR.Framework.Core.Persistence;

namespace HR.EmployeeContext.Domain.Employees.Services
{
    public interface IEmployeeRepository
    {
        void Create(Employee employee);
        Employee GetEmployee(Guid employeeId);
        void Update(Employee employee);
        void Remove(Employee employee); 
        bool Contains(Expression<Func<Employee,bool>> predicate);
        bool IsExist(Guid employeeId);
    }
}
