﻿using ECommerce.WebUI.DTOs.BasketDtos;

namespace ECommerce.WebUI.Services.BasketServices
{
    public class BasketService(HttpClient _client) : IBasketService
    {
        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
            var basket = await GetBasketAsync();
            if(basket != null)
            {
                basket.BasketItems.Add(basketItemDto);
            }
            await SaveBasketAsync(basket);

        }

        public async Task<bool> DeleteBasketAsync(string ProductId)
        {
            var basket = await GetBasketAsync();
            var deleteItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == ProductId);
            basket.BasketItems.Remove(deleteItem);
            await SaveBasketAsync(basket);
            return true;
        }

        public async Task<BasketDto> GetBasketAsync()
        {
            return await _client.GetFromJsonAsync<BasketDto>("baskets");
        }

        public async Task SaveBasketAsync(BasketDto basketDto)
        {
            await _client.PostAsJsonAsync("baskets", basketDto);

        }
    }
}
