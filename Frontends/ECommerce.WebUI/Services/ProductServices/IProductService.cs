
using ECommerce.WebUI.DTOs.ProductDtos;

namespace ECommerce.WebUI.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllAsync();
        Task<ResultProductDto> GetByIdAsync(string id);
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(string id);
    }
}
