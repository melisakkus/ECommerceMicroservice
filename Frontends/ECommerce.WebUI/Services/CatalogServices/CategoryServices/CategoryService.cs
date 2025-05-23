using ECommerce.WebUI.DTOs.CatalogDtos.CategoryDtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ECommerce.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService(HttpClient _client) : ICategoryService
    {
        //private readonly HttpClient _client;

        //public CategoryService(HttpClient client)
        //{
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer","token");
        //    _client = client;
        //}

        public async Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("categories", createCategoryDto);
        }

        public async Task DeleteAsync(string id)
        {
            await _client.DeleteAsync("categories/"+id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<ResultCategoryDto> GetByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<ResultCategoryDto>("categories/" + id);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync("categories", updateCategoryDto);
        }
    }
}
