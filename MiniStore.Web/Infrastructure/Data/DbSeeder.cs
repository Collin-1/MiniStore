using MiniStore.Web.Domain.Entities;

namespace MiniStore.Web.Infrastructure.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (db.Products.Any()) return;

        db.Products.AddRange(
            new Product { Name = "Bearing 6203", Description = "Standard deep groove bearing", Price = 59.99m},
            new Product { Name = "V-Belt A42", Description = "Industrial belt size A42", Price = 89.50m },
            new Product { Name = "Electric Motor 1.5kW", Description = "Single-phase motor", Price = 1899.00m }
        );

        await db.SaveChangesAsync();
    }
}