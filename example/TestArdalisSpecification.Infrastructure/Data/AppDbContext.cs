using Ardalis.Specification.EntityFrameworkCore.Audit;
using Microsoft.EntityFrameworkCore;
using TestArdalisSpecification.Core.Entities;

namespace TestArdalisSpecification.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Audits> Audits { get; set; } // from library
    }
}
