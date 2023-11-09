using Microsoft.EntityFrameworkCore;
using Nov11thPractice.Configurations;
using Nov11thPractice.Models;

namespace Nov11thPractice.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
        base.OnModelCreating(modelBuilder);
    }
}