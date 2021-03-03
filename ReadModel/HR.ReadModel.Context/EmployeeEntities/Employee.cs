using System;
using System.Collections.Generic;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class Employee
    {
        public Employee()
        {
            AssignShifts = new HashSet<AssignShift>();
            Contracts = new HashSet<Contract>();
            Ios = new HashSet<Io>();
        }

        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public long PersonalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AssignShift> AssignShifts { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Io> Ios { get; set; }
    }
}
