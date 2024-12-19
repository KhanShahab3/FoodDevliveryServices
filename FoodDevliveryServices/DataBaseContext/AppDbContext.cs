using FoodDevliveryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDevliveryServices.DataBaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<DeliveryRoute> DeliveryRoutes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public DbSet<CompanyInventory> CompanyInventories { get; set; }
        public DbSet<DeliveryItem> DeliveryItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drivers>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();  // Ensures auto-increment
        }

        // Optionally, override OnModelCreating to configure relationships or constraints if needed


    }
}

