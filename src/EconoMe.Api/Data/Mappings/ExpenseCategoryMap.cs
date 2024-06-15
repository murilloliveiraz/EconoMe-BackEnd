using EconoMe.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EconoMe.Api.Data.Mappings
{
    public class ExpenseCategoryMap : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.ToTable("ExpenseCategory")
            .HasKey(p => p.Id);

            builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(fk => fk.UserId);

            builder.Property(p => p.Description)
            .HasColumnType("VARCHAR")
            .IsRequired();
            
            builder.Property(p => p.Note)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.RegistrationDate)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.InactivationDate)
            .HasColumnType("timestamp");
        }
    }
}