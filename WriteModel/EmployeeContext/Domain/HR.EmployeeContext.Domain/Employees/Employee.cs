using System;
using System.Collections.Generic;
using System.Linq;
using HR.EmployeeContext.Domain.Employees.Exceptions;
using HR.EmployeeContext.Domain.Employees.Services;
using HR.Framework.Core.Domain;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees
{
    public class Employee : EntityBase , IAggregateRoot<Employee>
    {

        private INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IShiftAcl shiftAcl;

        public Employee(INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
                        IShiftAcl shiftAcl,
                        string name,
                        string nationalCode)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.shiftAcl = shiftAcl;
            SetName(name);
            SetNationalCode(nationalCode);
        }

        public Employee()
        {

        }
        public string Name { get; private set; }
        public string NationalCode { get; private set; }
        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
        public ICollection<AssignShift> AssignShifts { get; set; } = new HashSet<AssignShift>();
        public ICollection<IO> IOs { get; set; } = new HashSet<IO>();


        public void AddContract(Contract contract)
        {
            if (Contracts.Any(c => (c.StartDate <= contract.StartDate && c.EndDate >= contract.StartDate)))
                throw new EmployeeStartDateOfContractConflictedWithOtherContracts();

            if (Contracts.Any(c => c.StartDate <= contract.EndDate && c.EndDate >= contract.EndDate))
                throw new EmployeeEndDateOfContractConflictedWithOtherContracts();

            if (Contracts.Any(c => c.StartDate >= contract.StartDate && c.EndDate <= contract.EndDate))
                throw new EmployeeStartAndEndDateOfContractConflictedWithOtherContracts();

            Contracts.Add(contract);
        }

        public void RemoveContract(Contract contract)
        {
            Contracts.Remove(contract);
        }

        public void Initial(INationalCodeDuplicationChecker nationalCodeDuplicationChecker)
        {
            
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
        }
        public void AddAssignShift(AssignShift assignShift)
        {
            AssignShifts.Add(assignShift);
        }



        public void AddIO(IO io)
        {
            var employeeShiftBAseOnIoDate = AssignShifts.Where(a => a.StartDate < io.Date)
                .OrderByDescending(a => a.StartDate)
                .First();
            var dateDiff = (io.Date - employeeShiftBAseOnIoDate.StartDate).Days;
            var assignedSegment = shiftAcl.GetShiftSegmentDto(employeeShiftBAseOnIoDate.ShiftId);
            var mod = (dateDiff + employeeShiftBAseOnIoDate.Index) % assignedSegment.Count;
            if (mod == 0)
                mod = assignedSegment.Count;
            var intMod = Convert.ToInt32(mod);
            var shiftSegmentBaseOnIoDate = assignedSegment[intMod - 1];
            if (shiftSegmentBaseOnIoDate.StartTime > io.ArrivalTime || shiftSegmentBaseOnIoDate.EndTime < io.ExitTime)
                throw new EnteredTimeIsNotInSegmentInside();
            IOs.Add(io);
        }

      

        public void SetNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                throw new NationalCodeIsRequiredException();


            if (nationalCode.Any(n => !char.IsDigit(n)))
                throw new NationalCodeMustBeDigitException();


            if (nationalCodeDuplicationChecker.IsDuplicated(Name))
                throw new NationalCodeMustBeUniqueException();
            NationalCode = nationalCode;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FirstNameIsRequiredException();
            Name = name;
        }
    }
}
