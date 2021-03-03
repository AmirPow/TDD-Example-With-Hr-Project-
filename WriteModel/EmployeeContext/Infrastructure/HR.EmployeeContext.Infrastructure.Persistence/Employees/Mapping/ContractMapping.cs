using System.Data;
using HR.EmployeeContext.Domain.Employees;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class ContractMapping : EntityMappingBase<Contract>
    {
        public override void Configure(EntityTypeBuilder<Contract> builder)
        {
            Initial(builder);
            builder.Property(a => a.StartDate)
                .HasColumnType(nameof(SqlDbType.Date))
                .IsRequired();
            builder.Property(a => a.EndDate)
                .HasColumnType(nameof(SqlDbType.Date))
                .IsRequired();
            builder.HasOne<Employee>()
                .WithMany(a => a.Contracts)
                .HasForeignKey(e=>e.EmployeeId)
                .HasConstraintName("FK_Employee_Contracts");
        }
    }
}
