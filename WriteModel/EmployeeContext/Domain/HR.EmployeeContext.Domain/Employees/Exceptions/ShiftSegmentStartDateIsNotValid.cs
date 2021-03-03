﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
    public class ShiftSegmentStartDateIsNotValid : DomainException
    {
        public override string Message => Resource.Resource.ShiftSegmentStartDateIsNotValid;
    }
}
