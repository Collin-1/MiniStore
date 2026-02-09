using MiniStore.Application.ViewModels;

namespace MiniStore.Application.Services;

public interface IOrderService
{
    Task<int> CreateOrderAsync(string userId, CheckoutVm checkout);
    Task<List<object>> GetMyOrdersAsync(string userId);
}
