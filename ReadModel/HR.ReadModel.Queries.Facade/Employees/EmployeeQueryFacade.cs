using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.ReadModel.Context.EmployeeEntities;
using HR.ReadModel.Queries.Contracts.Employees;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts;
using Microsoft.EntityFrameworkCore;

namespace HR.ReadModel.Queries.Facade.Employees
{
    public class EmployeeQueryFacade : IEmployeeQueryFacade
    {
        public List<EmployeeDto> GetEmployee(string keyWord)
        {
            using (var context = new HRContext())
            {
                return (from employee in context.Employees
                    where employee.PersonalCode.ToString().Contains(keyWord)
                    select new EmployeeDto
                    {
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        PersonalCode = employee.PersonalCode,
                        NationalCode = employee.NationalCode
                    }).ToList();

            }
        }
    }
}
