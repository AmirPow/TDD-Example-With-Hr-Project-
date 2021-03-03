using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.EmployeeContext.Domain.Employees;
using HR.Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.EmployeeContext.Infrastructure.Persistence.Employees.Mapping
{
    public class IOMapping : EntityMappingBase<IO>
    {
        public override void Configure(EntityTypeBuilder<IO> builder)
        {
            Initial(builder);
            builder.Property(a => a.EmployeeId).HasColumnType(nameof(SqlDbType.
                UniqueIdentifier)).IsRequired();
            builder.Property(a => a.Date).HasColumnType(nameof(SqlDbType.Date));
            builder.Property(a => a.ArrivalTime).HasColumnType(nameof(SqlDbType.VarChar)).HasMaxLength(8);
            builder.Property(a => a.ExitTime).HasColumnType(nameof(SqlDbType.VarChar)).HasMaxLength(8);
            builder.HasOne<Employee>()
                .WithMany(a => a.IOs)
                .HasForeignKey(e => e.EmployeeId)
                .HasConstraintName("FK_Employee_IOs");

        }
    }
}
