namespace ECommerce.Catalog.Entities.Common
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }

        public string CategoryId { get; set; }
    }
}
