﻿// <auto-generated />
using System;
using EconoMe.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EconoMe.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240620224331_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EconoMe.Api.Domain.Models.Payment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("AmountPaid")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("InactivationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Note")
                        .HasColumnType("VARCHAR");

                    b.Property<double>("OriginalAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("ReferenceDate")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp");

                    b.Property<long>("TransactionCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TransactionCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("payment", (string)null);
                });

            modelBuilder.Entity("EconoMe.Api.Domain.Models.TransactionCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime?>("InactivationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Note")
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("transactioncategory", (string)null);
                });

            modelBuilder.Entity("EconoMe.Api.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime?>("InactivationDate")
                        .HasColumnType("timestamp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("EconoMe.Api.Domain.Models.Payment", b =>
                {
                    b.HasOne("EconoMe.Api.Domain.Models.TransactionCategory", "TransactionCategory")
                        .WithMany()
                        .HasForeignKey("TransactionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EconoMe.Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EconoMe.Api.Domain.Models.TransactionCategory", b =>
                {
                    b.HasOne("EconoMe.Api.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
