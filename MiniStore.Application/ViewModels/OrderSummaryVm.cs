namespace MiniStore.Application.ViewModels;

public class OrderSummaryVm
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    public decimal Total { get; set; }
}
