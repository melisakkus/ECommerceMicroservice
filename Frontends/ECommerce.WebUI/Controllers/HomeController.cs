using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerce.WebUI.Models;
using ECommerce.WebUI.Services.ProductServices;

namespace ECommerce.WebUI.Controllers;

public class HomeController(IProductService _productService) : Controller
{

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync();
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
