using System;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class IO : EntityBase
    {
        private readonly IEmployeeRepository employeeRepository;


        public Guid EmployeeId { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan ArrivalTime { get; private set; }
        public TimeSpan ExitTime { get; private set; }

        public IO(
            IEmployeeRepository employeeRepository , 
            Guid employeeId ,
            DateTime date ,
            TimeSpan arrivalTime ,
            TimeSpan exitTime )
        {
            this.employeeRepository = employeeRepository;
            SetEmployeeId(employeeRepository, employeeId);
            Date = date;
            ArrivalTime = arrivalTime;
            ExitTime = exitTime;
        }

        private void SetEmployeeId(IEmployeeRepository employeeRepository, Guid employeeId)
        {
            if (!employeeRepository.IsExist(employeeId))
                throw new IOEmployeeIdNullException();

            EmployeeId = employeeId;
        }
    }
}
