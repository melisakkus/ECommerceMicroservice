using ECommerce.WebUI.DTOs.BasketDtos;
using ECommerce.WebUI.Services.BasketServices;
using ECommerce.WebUI.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class BasketController(IProductService productService, IBasketService basketService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToBasket(string id)
        {
            var product = await productService.GetByIdAsync(id);
            var basketItem = new BasketItemDto
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = 1
            };
            await basketService.AddBasketItemAsync(basketItem);
            return RedirectToAction("Index");
        }


    }
}
