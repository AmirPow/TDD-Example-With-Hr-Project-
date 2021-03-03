using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HR.EmployeeContext.Domain;
using HR.EmployeeContext.Domain.Employees;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.Persistence;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;


namespace HR.EmployeeContext.Infrastructure.Persistence.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee>  , IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {

        }
        public  void Create(Employee employee)
        {
            base.Create(employee);
        }

        public Employee GetEmployee(Guid employeeId)
        {
            return GetById(employeeId);
        }

        public void Update(Employee employee)
        {
            base.Update(employee);
        }

        public bool Contains(Expression<Func<Employee, bool>> predicate)
        {
            return dbContext.Set<Employee>().Any(predicate);
        }

        public bool IsExist(Guid employeeId)
        {
            return dbContext.Set<Employee>().Any(c => c.Id == employeeId);
        }

        public  void Remove(Employee employee)
        {
            dbContext.Remove(employee);
        }

        protected override IEnumerable<Expression<Func<Employee, dynamic>>> GetAggregateExpression()
        {
            yield return c => c.Contracts;
            yield return c => c.AssignShifts;
            yield return c => c.IOs;
        }
    }
}
