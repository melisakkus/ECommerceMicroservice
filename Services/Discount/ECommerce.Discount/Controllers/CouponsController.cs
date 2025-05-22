using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await _context.Coupones.ToListAsync();
            var couponList = coupons.Select(x => new ResultCouponDto
            {
                CouponId = x.CouponId,
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                ExpiredDate = x.ExpiredDate,
                ProductId = x.ProductId,
            }).ToList();
            return Ok(couponList);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            var coupon = new Coupon
            {
                Code = createCouponDto.Code,
                DiscountRate = createCouponDto.DiscountRate,
                ExpiredDate = createCouponDto.ExpiredDate,
                ProductId = createCouponDto.ProductId,
            };
            await _context.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return Ok("Kupon başarıyla oluşturuldu.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await _context.Coupones.FindAsync(id);
            if(coupon is null)
            {
                return BadRequest("Kupon Bulunamadı");
            }
            var value = new ResultCouponDto
            {
                CouponId = coupon.CouponId,
                Code = coupon.Code,
                DiscountRate = coupon.DiscountRate,
                ExpiredDate = coupon.ExpiredDate,
                ProductId = coupon.ProductId,
            };
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {

            var coupon = new Coupon
            {
                CouponId = updateCouponDto.CouponId,
                Code = updateCouponDto.Code,
                DiscountRate = updateCouponDto.DiscountRate,
                ExpiredDate = updateCouponDto.ExpiredDate,
                ProductId = updateCouponDto.ProductId,
            };
            _context.Update(coupon);
            await _context.SaveChangesAsync();
            return Ok("Güncelleme işlemi başarılı.");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await _context.Coupones.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Kupon Bulunamadı");
            }
            _context.Remove(coupon);
            await _context.SaveChangesAsync();
            return Ok("Silme işlemi başarılı.");
        }
    }
}
