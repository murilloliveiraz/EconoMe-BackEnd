using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoMe.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EconoMe.Api.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user")
            .HasKey(p => p.Id);

            builder.Property(p => p.Email)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.Password)
            .HasColumnType("VARCHAR")
            .IsRequired();

            builder.Property(p => p.RegistrationDate)
            .HasColumnType("timestamp")
            .IsRequired();

            builder.Property(p => p.InactivationDate)
            .HasColumnType("timestamp");
        }
    }
}