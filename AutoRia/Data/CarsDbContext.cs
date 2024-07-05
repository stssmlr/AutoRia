using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using AutoRia.Entities;

namespace shopL.Data
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AutoRia;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(new List<Car>()
            {
                new Car() {Id= 1, Mark = "Audi", Model="A8",Year=2018 ,CategoryId=2, Discount=5, Price= 19899, Quantity=2},
                new Car() {Id= 2, Mark = "Mercedes-Benz", Model="GLS",Year=2019 ,CategoryId=1, Discount=0, Price= 29999, Quantity=3},
                new Car() {Id= 3, Mark = "BMW", Model="X5",Year=2014 ,CategoryId=1, Discount=0, Price= 14999, Quantity=1},
                new Car() {Id= 4, Mark = "Volkswagen", Model="Golf",Year=2015 ,CategoryId=7, Discount=0, Price= 12999, Quantity=6},

            });

            modelBuilder.Entity<Category>().HasData(new List<Category>()
            {
                 new Category() { Id = 1, Name = "Crossover" },
                new Category() { Id = 2, Name = "Sedan" },
                new Category() { Id = 3, Name = "Universal" },
                new Category() { Id = 4, Name = "Miniven" },
                new Category() { Id = 5, Name = "Pickup" },
                new Category() { Id = 6, Name = "Fastback" },
                new Category() { Id = 7, Name = "Hatchback" },

            });
        }

        
    }
}
