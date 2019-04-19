using CarRentalApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRentalApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .HasOne(order => order.Car)                         
                        .WithOne(car => car.Order)
                        .HasForeignKey<Order>(order => order.CarId);
            modelBuilder.Entity<Order>()
                        .HasOne(order => order.User)
                        .WithOne(user => user.Order)
                        .HasForeignKey<Order>(order => order.UserId);

        }
    }
}
