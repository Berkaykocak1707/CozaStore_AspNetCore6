using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record CouponDto
    {

        public int? CouponId { get; init; }


        public int? CouponStock { get; set; }

        [Required]
        [StringLength(100)]
        public string? CouponCode { get; init; }


        public double? CouponDiscountPercentage { get; init; }
        public bool IsActive
        {
            get; init;
        }


        public DateTime EndDate { get; set; }
    }
}