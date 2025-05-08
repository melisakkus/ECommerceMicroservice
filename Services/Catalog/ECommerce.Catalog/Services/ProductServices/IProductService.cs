using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Entities.Common;
using ECommerce.Catalog.Repositories;

namespace ECommerce.Catalog.Services.ProductServices
{
    public interface IProductService : IRepository<Product>
    {
    }
}
