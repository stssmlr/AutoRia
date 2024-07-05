﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shopL.Data;

#nullable disable

namespace AutoRia.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    partial class CarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoRia.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

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

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Archived = false,
                            CategoryId = 2,
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
                            Archived = false,
                            CategoryId = 1,
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
                            Archived = false,
                            CategoryId = 1,
                            Discount = 0,
                            Mark = "BMW",
                            Model = "X5",
                            Price = 14999m,
                            Quantity = 1,
                            Year = 2014
                        },
                        new
                        {
                            Id = 4,
                            Archived = false,
                            CategoryId = 7,
                            Discount = 0,
                            Mark = "Volkswagen",
                            Model = "Golf",
                            Price = 12999m,
                            Quantity = 6,
                            Year = 2015
                        });
                });

            modelBuilder.Entity("AutoRia.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Crossover"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sedan"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Universal"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Miniven"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pickup"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Fastback"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Hatchback"
                        });
                });

            modelBuilder.Entity("AutoRia.Entities.Car", b =>
                {
                    b.HasOne("AutoRia.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AutoRia.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
