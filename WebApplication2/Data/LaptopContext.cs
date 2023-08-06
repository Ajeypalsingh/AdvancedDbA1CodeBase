using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication2.Migrations;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class LaptopContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().HasKey(l => l.Number);
            modelBuilder.Entity<StoreLocation>().HasKey(sl => sl.StoreNumber);
            modelBuilder.Entity<Brand>().HasKey(b => b.Id);

            modelBuilder.Entity<StoreLaptop>().HasKey(sl =>sl.Id);

            modelBuilder.Entity<StoreLaptop>()
                .HasOne(sl => sl.Store)
                .WithMany(s => s.storeLaptops)
                .HasForeignKey(sl => sl.StoreId);

            modelBuilder.Entity<StoreLaptop>()
                .HasOne(sl => sl.Laptop)
                .WithMany(l => l.storeLaptops)
                .HasForeignKey(ls => ls.LaptopId);
        }

        public LaptopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<StoreLocation> StoreLocations { get; set; } = null!;
        public DbSet<StoreLaptop> StoreLaps { get; set; } = null!;
    }  
    
}
