using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class ContractEndDateCouldNotBeLessThanStartDateException: DomainException
   {
       public override string Message => Resource.Resource.ContractsStartDateMustBiggerThanLastContractEndDateException;
   }
}
