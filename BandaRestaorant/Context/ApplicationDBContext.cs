using BandaRestaorant.Models;
using Microsoft.EntityFrameworkCore;

namespace BandaRestaorant.Context
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuOrder> MenuOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<TakeAway> TakeAways { get; set; }
        public DbSet<InRestaorant> InRestaorants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "Server=DESKTOP-5NAMNAV;Database=BandaRestaorant;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithOne(o => o.Payment)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MenuOrder>()
                .HasKey(mo => new { mo.OrderId, mo.MenuId });
            modelBuilder.Entity<MenuOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(o => o.MenuOrders)
                .HasForeignKey(mo => mo.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MenuOrder>()
                .HasOne(mo => mo.Menu)
                .WithMany(m => m.MenuOrders)
                .HasForeignKey(mo => mo.MenuId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Delivery>().ToTable("Deliveries");
            modelBuilder.Entity<TakeAway>().ToTable("TakeAways");
            modelBuilder.Entity<InRestaorant>().ToTable("InRestaorants");

        }
    }
}
