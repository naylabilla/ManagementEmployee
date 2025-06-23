using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Gender data
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" }
            );

            // Seed Department data
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Digital Transformation" },
                new Department { Id = 2, Name = "Finance" },
                new Department { Id = 3, Name = "Human Resources" },
                new Department { Id = 4, Name = "Engineering" },
                new Department { Id = 5, Name = "Sales" },
                new Department { Id = 6, Name = "Operations" }
            );

            // Seed Employee data
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, SesaId = "SESA112233", Name = "ORTEGA, William", GenderId = 1, DepartmentId = 1 },
                new Employee { Id = 2, SesaId = "SESA112234", Name = "DIEGO, Mark Anthony", GenderId = 1, DepartmentId = 2 },
                new Employee { Id = 3, SesaId = "SESA112235", Name = "MARTINEZ, Rebecca", GenderId = 2, DepartmentId = 3 }
            );

            // Configure relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Gender)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.GenderId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}