using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class EmployeeEndDateOfContractConflictedWithOtherContracts : DomainException
   {
       public override string Message => Resource.Resource.EmployeeEndDateOfContractConflictedWithOtherContracts;
   }
}
