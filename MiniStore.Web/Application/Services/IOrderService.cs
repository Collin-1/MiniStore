using MiniStore.Web.Models.ViewModels;

namespace MiniStore.Web.Application.Services;

public interface IOrderService
{
    Task<int> CreateOrderAsync(string userId, CheckoutVm checkout);
    Task<List<object>> GetMyOrdersAsync(string userId);
}
