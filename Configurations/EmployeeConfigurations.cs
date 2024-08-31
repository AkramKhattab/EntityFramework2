using C42_G04_EF02.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C42_G04_EF02.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(E => E.Id); // Set primary key
            builder.Property(E => E.Id)
                    .UseIdentityColumn(10, 10); // Use identity column with seed 10 and increment 10
            builder.Property(E => E.EmployeeName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired(); // Configure Name property
            builder.Property(E => E.Salary)
                .HasColumnType("decimal(18, 2)")
                .IsRequired(false); // Configure Salary property
        }
    }
}