namespace ECommerce.Discount.DTOs
{
    public class UpdateCouponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string ProductId { get; set; }
    }
}
