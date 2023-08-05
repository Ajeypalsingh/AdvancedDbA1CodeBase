using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class LaptopContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().HasKey(l => l.Number);
            modelBuilder.Entity<StoreLocation>().HasKey(sl => sl.StoreNumber);
        }

        public LaptopContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Laptop> Laptops { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;
    }  
    
}
