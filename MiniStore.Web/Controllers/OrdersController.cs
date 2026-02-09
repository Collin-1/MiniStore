using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniStore.Application.Services;
using MiniStore.Application.ViewModels;

namespace MiniStore.Web.Controllers;

[Authorize]
public class OrdersController : Controller
{
    private readonly IOrderService _orders;
    private readonly UserManager<IdentityUser> _userManager;

    public OrdersController(IOrderService orders, UserManager<IdentityUser> userManager)
    {
        _orders = orders;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(CheckoutVm vm)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null) return Challenge();

        var orderId = await _orders.CreateOrderAsync(user.Id, vm);
        return RedirectToAction(nameof(Details), new { id = orderId });
    }

    public async Task<IActionResult> My()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null) return Challenge();

        var orders = await _orders.GetMyOrdersAsync(user.Id);
        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user is null) return Challenge();

        var order = await _orders.GetOrderSummaryAsync(id, user.Id);
        if (order is null) return NotFound();
        return View(order);
    }
}
