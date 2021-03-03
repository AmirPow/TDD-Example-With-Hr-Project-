using HR.Framework.Domain;

namespace HR.EmployeeContext.Domain.Employees.Exceptions
{
   public class ContractsStartDateMustBiggerThanLastContractEndDateException: DomainException
   {
       public override string Message => Resource.Resource.ContractsStartDateMustBiggerThanLastContractEndDateException;
   }
}
