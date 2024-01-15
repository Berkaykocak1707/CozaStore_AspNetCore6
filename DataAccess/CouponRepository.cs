using DataAccess.Contracts;
using Entities.Models;

namespace DataAccess.Repository
{
    public class CouponRepository : RepositoryBase<Coupon>, ICouponRepository
    {
        public CouponRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Coupon> Coupons => FindAll(false);
        
        public void CreateCoupon(Coupon coupon)
        {
            Create(coupon);
            _context.SaveChanges();
        }

        public void DeleteCoupon(Coupon coupon)
        {
            Delete(coupon);
            _context.SaveChanges();
        }

        public IQueryable<Coupon> FindAllCoupons()
        {
            return FindAll(false);
        }

        public Coupon GetCouponById(int? couponId)
        {
            return FindByCondition(coupon => coupon.CouponId.Equals(couponId), false);
        }

        public Coupon GetCouponByCouponName(string couponName)
        {
            return FindByCondition(c => c.CouponCode.Equals(couponName),false);
        }

        public void UpdateCoupon(Coupon coupon)
        {
            Update(coupon);
            _context.SaveChanges();
        }
    }
}