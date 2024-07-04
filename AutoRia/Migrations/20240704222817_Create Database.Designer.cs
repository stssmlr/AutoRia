﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shopL.Data;

#nullable disable

namespace AutoRia.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20240704222817_Create Database")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoRia.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Sedan",
                            Discount = 5,
                            Mark = "Audi",
                            Model = "A8",
                            Price = 19899m,
                            Quantity = 2,
                            Year = 2018
                        },
                        new
                        {
                            Id = 2,
                            Category = "Crossover",
                            Discount = 0,
                            Mark = "Mercedes-Benz",
                            Model = "GLS",
                            Price = 29999m,
                            Quantity = 3,
                            Year = 2019
                        },
                        new
                        {
                            Id = 3,
                            Category = "Crossover",
                            Discount = 0,
                            Mark = "BMW",
                            Model = "X5",
                            Price = 14999m,
                            Quantity = 1,
                            Year = 2014
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
