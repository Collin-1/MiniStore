using Microsoft.EntityFrameworkCore;
using MiniStore.Application.Services;
using MiniStore.Application.ViewModels;
using MiniStore.Infrastructure.Data;

namespace MiniStore.Infrastructure.Services;

public class CatalogService : ICatalogService
{
    private readonly AppDbContext _db;

    public CatalogService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ProductListItemVm>> GetProductsAsync()
    {
        return await _db.Products
            .OrderBy(p => p.Name)
            .Select(p => new ProductListItemVm
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }

    public async Task<ProductDetailsVm?> GetProductAsync(int id)
    {
        return await _db.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDetailsVm
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            })
            .FirstOrDefaultAsync();
    }
}
