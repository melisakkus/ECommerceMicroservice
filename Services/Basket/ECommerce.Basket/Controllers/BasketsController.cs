using ECommerce.Basket.Entities.DTOs;
using ECommerce.Basket.Services.BasketServices;
using ECommerce.Basket.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService _basketService,IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var userId = _userService.GetUserId;
            var values = await _basketService.GetBasketAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketDto basketDto)
        {
            await _basketService.SaveOrUpdateAsync(basketDto);
            return Ok("Sepet değişiklikleri kaydedildi.");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete()
        {
            var userId = _userService.GetUserId;
            var result = await _basketService.DeleteAsync(userId);
            return result ? Ok("Basked Deleted") : BadRequest("Basked Delete Failed");
        }
    }
}
