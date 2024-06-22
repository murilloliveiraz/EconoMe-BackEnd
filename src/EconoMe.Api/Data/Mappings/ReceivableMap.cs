using EconoMe.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EconoMe.Api.Data.Mappings
{
    public class ReceivableMap : IEntityTypeConfiguration<Receivable>
    {
        public void Configure(EntityTypeBuilder<Receivable> builder)
        {
            builder.ToTable("receivable")
            .HasKey(p => p.Id);

            builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(fk => fk.UserId);
            
            builder.HasOne(p => p.TransactionCategory)
            .WithMany()
            .HasForeignKey(fk => fk.TransactionCategoryId);

            builder.Property(p => p.Description)
            .HasColumnType("VARCHAR")
            .IsRequired();
            
            builder.Property(p => p.OriginalAmount)
            .HasColumnType("double precision")
            .IsRequired();
            
            builder.Property(p => p.AmountReceived)
            .HasColumnType("double precision")
            .IsRequired();
            
            builder.Property(p => p.Note)
            .HasColumnType("VARCHAR");

            builder.Property(p => p.RegistrationDate)
            .HasColumnType("timestamp")
            .IsRequired();
            
            builder.Property(p => p.ExpirationDate)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.ReceiptDate)
            .HasColumnType("timestamp");
            
            builder.Property(p => p.ReferenceDate)
            .HasColumnType("timestamp");
            
            builder.Property(p => p.InactivationDate)
            .HasColumnType("timestamp");
        }
    }
}