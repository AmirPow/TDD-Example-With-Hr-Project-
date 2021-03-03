using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HR.ReadModel.Context.EmployeeEntities
{
    public partial class HRContext : DbContext
    {
        public HRContext()
        {
        }

        public HRContext(DbContextOptions<HRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignShift> AssignShifts { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Io> Ios { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftSegment> ShiftSegments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HR;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignShift>(entity =>
            {
                entity.ToTable("AssignShift", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_AssignShift_EmployeeId");

                entity.HasIndex(e => e.SegmentId, "IX_AssignShift_SegmentId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AssignShifts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_AssignShifts");

                entity.HasOne(d => d.Segment)
                    .WithMany(p => p.AssignShifts)
                    .HasForeignKey(d => d.SegmentId)
                    .HasConstraintName("FK_ShiftSegment_AssignShifts");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.ToTable("Contract", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_Contract_EmployeeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_Contracts");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "EmployeeContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Io>(entity =>
            {
                entity.ToTable("IO", "EmployeeContext");

                entity.HasIndex(e => e.EmployeeId, "IX_IO_EmployeeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ExiTime)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Ios)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Employee_IOs");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift", "ShiftContext");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ShiftTitle)
                    .IsRequired()
                    .HasMaxLength(350);
            });

            modelBuilder.Entity<ShiftSegment>(entity =>
            {
                entity.ToTable("ShiftSegment", "ShiftContext");

                entity.HasIndex(e => e.ShiftId, "IX_ShiftSegment_ShiftId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndTime)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ShiftSegments)
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK_Shift_ShiftPeriods");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
