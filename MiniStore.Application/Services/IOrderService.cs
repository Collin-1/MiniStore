using MiniStore.Application.ViewModels;

namespace MiniStore.Application.Services;

public interface IOrderService
{
    Task<int> CreateOrderAsync(string userId, CheckoutVm checkout);
    Task<List<OrderSummaryVm>> GetMyOrdersAsync(string userId);
    Task<OrderSummaryVm?> GetOrderSummaryAsync(int orderId, string userId);
}
