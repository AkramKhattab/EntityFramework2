using C42_G04_EF02.Contexts;
using C42_G04_EF02.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C42_G04_EF02.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(D => D.Id); // Set primary key
            builder.Property(D => D.Id).UseIdentityColumn(100, 100); // Use identity column with seed 100 and increment 100
            builder.Property(D => D.DeptName)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired(); // Configure DeptName property
        }
    }
}