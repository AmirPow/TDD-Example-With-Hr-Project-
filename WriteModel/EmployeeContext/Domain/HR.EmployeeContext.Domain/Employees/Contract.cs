using System;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Contract:EntityBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public Guid EmployeeId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Contract(IEmployeeRepository employeeRepository, Guid employeeId, DateTime startDate, DateTime endDate)
        {
            this.employeeRepository = employeeRepository;
            EmployeeId = employeeId;

            SetDate(employeeRepository, startDate, endDate);
        }

        public void SetDate(IEmployeeRepository employeeRepository, DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ContractEndDateCouldNotBeLessThanStartDateException();

            if (!employeeRepository.IsExist(EmployeeId))
                throw new EmployeeIdOfContractIsNotExist();

            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
