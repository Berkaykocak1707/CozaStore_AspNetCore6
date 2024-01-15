
    namespace Entities.Models
    {
        public class Coupon
        {
            public int CouponId { get; set; }
            public int CouponStock { get; set; }
            public string CouponCode { get; set; }
            public double CouponDiscountPercentage { get; set; }
            public DateTime EndDate { get; set; }
            public bool IsActive
            {
                get
                {
                    return EndDate >= DateTime.Now && CouponStock > 0;
                }
            }
        
        }
    }