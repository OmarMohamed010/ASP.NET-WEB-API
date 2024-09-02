using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class Companycontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMAR\\TEW_SQLEXPRESS;Database=FirstWebApi;Integrated Security=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
