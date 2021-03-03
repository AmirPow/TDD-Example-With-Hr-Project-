using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.ReadModel.Queries.Contracts.Employees.DataContracts;

namespace HR.ReadModel.Queries.Contracts.Employees
{
    public interface IEmployeeQueryFacade
    {
        List<EmployeeDto> GetEmployee(string keyWord);
    }
}
