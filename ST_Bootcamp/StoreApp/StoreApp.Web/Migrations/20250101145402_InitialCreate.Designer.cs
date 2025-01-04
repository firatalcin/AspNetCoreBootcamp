﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApp.Data.Concrete;

#nullable disable

namespace StoreApp.Web.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20250101145402_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StoreApp.Data.Concrete.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S24",
                            Price = 50000m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S25",
                            Price = 60000m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S26",
                            Price = 70000m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S27",
                            Price = 80000m
                        },
                        new
                        {
                            Id = 5,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S28",
                            Price = 90000m
                        },
                        new
                        {
                            Id = 6,
                            Category = "Telefon",
                            Description = "güzel telefon",
                            Name = "Samsung S29",
                            Price = 100000m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}