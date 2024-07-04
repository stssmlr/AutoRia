using Microsoft.EntityFrameworkCore;
using AutoRia.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace shopL.Data
{
    public class CarsDbContext : DbContext
    {
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
                new Car() {Id= 1, Mark = "Audi", Model="A8",Year=2018 ,Category="Sedan", Discount=5, Price= 19899, Quantity=2},
                new Car() {Id= 2, Mark = "Mercedes-Benz", Model="GLS",Year=2019 ,Category="Crossover", Discount=0, Price= 29999, Quantity=3},
                new Car() {Id= 3, Mark = "BMW", Model="X5",Year=2014 ,Category="Crossover", Discount=0, Price= 14999, Quantity=1},

            });
        }

        public DbSet<Car> Cars { get; set; }
    }
}
