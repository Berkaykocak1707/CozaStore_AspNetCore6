using Entities.Models;

namespace DataAccess.Contracts
{
    public interface ICouponRepository : IRepositoryBase<Coupon>
    {
        IQueryable<Coupon> Coupons { get; }
        
        IQueryable<Coupon> FindAllCoupons();
        Coupon GetCouponById(int? couponId);
        Coupon GetCouponByCouponName(string couponName);
        void CreateCoupon(Coupon coupon);
        void UpdateCoupon(Coupon coupon);
        void DeleteCoupon(Coupon coupon);
    }
}