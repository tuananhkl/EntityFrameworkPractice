using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nov11thPractice.Data;
using Nov11thPractice.Models;

namespace Nov11thPractice.Configurations;

public class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        ConfigureMapping(builder);
        
        SeedEmployees(builder);
    }

    private static void ConfigureMapping(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.EmployeeId);
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Age).IsRequired().HasColumnType("int");
        builder.HasCheckConstraint("CK_Person_Age", "Age >= 0 AND Age <= 120"); // Age should be between 0 and 120)
        builder.Property(e => e.Department).IsRequired().HasMaxLength(50).IsUnicode(false);
    }
    
    private static void SeedEmployees(EntityTypeBuilder<Employee> builder)
    {
        builder.HasData(
            new Employee
            {
                EmployeeId = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Age = 30, Department = "HR"
            },
            new Employee
            {
                EmployeeId = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Age = 28, Department = "Finance"
            }
        );
    }
}