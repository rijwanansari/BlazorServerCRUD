using EmployeeMgmt.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgmt.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeQualification> EmployeesQualifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Employee>().Property(nameof(Employee.Gender)).HasConversion<string>();
            modelBuilder.Entity<EmployeeQualification>()
                .ToTable("EmployeeQualification")
                .HasOne(p => p.Employee)
                .WithMany(p => p.EmployeeQualifications)
                .HasForeignKey(p => p.EmployeeId);
            modelBuilder.Entity<EmployeeQualification>().Property(nameof(EmployeeQualification.Name)).HasConversion<string>();
        }
    }
}
