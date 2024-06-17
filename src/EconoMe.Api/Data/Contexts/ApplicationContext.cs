using EconoMe.Api.Data.Mappings;
using EconoMe.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EconoMe.Api.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> User {get; set;}
        public DbSet<TransactionCategory> TransactionCategory {get; set;}
        public DbSet<Payment> Payment {get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TransactionCategoryMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}