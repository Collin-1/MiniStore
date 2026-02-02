using MiniStore.Web.Models.ViewModels;

namespace MiniStore.Web.Application.Services;

public interface ICatalogService
{
    Task<List<ProductListItemVm>> GetProductsAsync();
    Task<ProductDetailsVm?> GetProductAsync(int id);
}