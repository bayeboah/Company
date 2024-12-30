using Microsoft.EntityFrameworkCore;

namespace Company.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Explicitly define relationships
            builder.Entity<Employees>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees) // Assumes Department has a collection of Employees
                .HasForeignKey(e => e.DepartmentId);


            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    DepartmentName = "Accounting",
                    ShortName = " ACC"

                },

                 new Department
                 {
                     Id = 2,
                     DepartmentName = "Marketing",
                     ShortName = " MKT" 
                   

                 },

                  new Department
                  {
                      Id = 3,
                      DepartmentName = "Administration",
                      ShortName = " ADMIN"

                  }

                );

            builder.Entity<Employees>().HasData(
                new Employees
                {
                    Id = 1,
                    EmployeeName = "Silas Yeboah",
                    EmployeeAge = 30,
                    DepartmentId = 1,
                    Hometown = "Techiman",
                    Residence = "West Legon"

                },

                  new Employees
                  {
                      Id = 2,
                      EmployeeName = "Bobby Brown",
                      EmployeeAge = 28,
                      DepartmentId = 2,
                      Hometown = "Accra",
                      Residence = "East Legon"

                  },
                    new Employees
                    {
                        Id = 3,
                        EmployeeName = "Drey Yeboah",
                        EmployeeAge = 26,
                        DepartmentId = 3,
                        Hometown = "Kumasi",
                        Residence = "Sakumono"

                    }

                );
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employees> employees { get; set; }
    }
}
