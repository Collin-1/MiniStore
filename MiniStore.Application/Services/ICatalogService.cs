using MiniStore.Application.ViewModels;

namespace MiniStore.Application.Services;

public interface ICatalogService
{
    Task<List<ProductListItemVm>> GetProductsAsync();
    Task<ProductDetailsVm?> GetProductAsync(int id);
}
