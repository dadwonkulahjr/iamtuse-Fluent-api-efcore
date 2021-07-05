using iamtuseFluentApi.Domain.Entities;
using iamtuseFluentApi.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace iamtuseFluentApi.Persistence.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
            builder.SeedDatabaseWithInitialData();

        }
    }
}
