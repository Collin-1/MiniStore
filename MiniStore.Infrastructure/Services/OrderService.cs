using Microsoft.EntityFrameworkCore;
using MiniStore.Application.Services;
using MiniStore.Application.ViewModels;
using MiniStore.Domain.Entities;
using MiniStore.Infrastructure.Data;

namespace MiniStore.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _db;

    public OrderService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<int> CreateOrderAsync(string userId, CheckoutVm checkout)
    {
        var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == checkout.ProductId);
        if (product is null) throw new InvalidOperationException("Product not found.");

        var order = new Order
        {
            UserId = userId,
            Items =
            {
                new Order.OrderItem
                {
                    ProductId = product.Id,
                    ProductNameSnapshot = product.Name,
                    UnitPriceSnapshot = product.Price,
                    Quantity = Math.Max(1, checkout.Quantity)
                }
            }
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order.Id;
    }

    public async Task<List<OrderSummaryVm>> GetMyOrdersAsync(string userId)
    {
        return await _db.Orders
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedUtc)
            .Select(o => new OrderSummaryVm
            {
                Id = o.Id,
                CreatedUtc = o.CreatedUtc,
                Total = o.Items.Sum(i => i.UnitPriceSnapshot * i.Quantity)
            })
            .ToListAsync();
    }

    public async Task<OrderSummaryVm?> GetOrderSummaryAsync(int orderId, string userId)
    {
        return await _db.Orders
            .Where(o => o.Id == orderId && o.UserId == userId)
            .Select(o => new OrderSummaryVm
            {
                Id = o.Id,
                CreatedUtc = o.CreatedUtc,
                Total = o.Items.Sum(i => i.UnitPriceSnapshot * i.Quantity)
            })
            .FirstOrDefaultAsync();
    }
}
