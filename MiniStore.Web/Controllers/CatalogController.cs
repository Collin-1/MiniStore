using Microsoft.AspNetCore.Mvc;
using MiniStore.Application.Services;

namespace MiniStore.Web.Controllers;

public class CatalogController : Controller
{
    private readonly ICatalogService _catalog;

    public CatalogController(ICatalogService catalog)
    {
        _catalog = catalog;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _catalog.GetProductsAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _catalog.GetProductAsync(id);
        if (product is null) return NotFound();
        return View(product);
    }
}