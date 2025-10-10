using Microsoft.EntityFrameworkCore;
using OptiTech.Core.Aggregates;
using OptiTech.Core.Entities;

namespace OptiTech.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(builder =>
            {
                builder.OwnsOne(o => o.Total, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("TotalAmount");
                    money.Property(m => m.Currency).HasColumnName("TotalCurrency");
                });
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.OwnsOne(p => p.Price, money =>
                {
                    money.Property(m => m.Amount).HasColumnName("PriceAmount");
                    money.Property(m => m.Currency).HasColumnName("PriceCurrency");
                });
            });
        }

    }
}
