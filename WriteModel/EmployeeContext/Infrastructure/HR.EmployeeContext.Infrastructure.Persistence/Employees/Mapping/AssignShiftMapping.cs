using System.Data;
using HR.EmployeeContext.Domain.Employees;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class AssignShiftMapping : EntityMappingBase<AssignShift>
    {
        public override void Configure(EntityTypeBuilder<AssignShift> builder)
        {
            Initial(builder);
            builder.Property(a => a.Index).HasColumnType(nameof(SqlDbType.Int)).IsRequired();
            builder.Property(a => a.EmployeeId).HasColumnType(nameof(SqlDbType.UniqueIdentifier)).IsRequired();
            builder.Property(a => a.ShiftId).HasColumnType(nameof(SqlDbType.UniqueIdentifier)).IsRequired();
            builder.Property(a => a.StartDate).HasColumnType(nameof(SqlDbType.Date));

            builder.HasOne<Employee>()
                .WithMany(a => a.AssignShifts)
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("FK_Employee_AssignShifts");

        }
    }
}
