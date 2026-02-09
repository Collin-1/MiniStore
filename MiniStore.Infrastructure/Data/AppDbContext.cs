using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniStore.Domain.Entities;

namespace MiniStore.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
