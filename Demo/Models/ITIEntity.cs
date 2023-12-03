using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ITIEntity:DbContext
    {
        public ITIEntity():base()
        {

        }

        public ITIEntity(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = MVCTest; Integrated Security = SSPI; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
