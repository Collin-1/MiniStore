using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MiniStore.Web.Domain.Entities;

public class Order
{
    public int Id {get; set;}
    public DateTime CreatedUtc {get; set; } = DateTime.UtcNow;

    public string UserId {get; set;} = "";
    public List<OrderItem> Items {get; set;} = new();

    public class OrderItem
    {
        public int Id {get; set;}
        public int ProductId {get; set;}
        public string ProductNameSnapshot { get; set;} = "";
        public decimal UnitPriceSnapshot {get; set;}
        public int Quantity {get; set;}
    }
}