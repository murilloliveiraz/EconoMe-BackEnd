using EconoMe.Api.Data.Mappings;
using EconoMe.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User {get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}