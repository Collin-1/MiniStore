using Microsoft.EntityFrameworkCore;
using MiniStore.Web.Domain.Entities;

namespace MiniStore.Web.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>().OwnsMany(o => o.Items, b =>
        {
            b.WithOwner().HasForeignKey("OrderId");
            b.Property<int>("Id");
            b.HasKey("Id");
        });
    }
}