using Entities.Dtos;
using Entities.Models;

public interface ICouponService
{
    IEnumerable<CouponDto> FindAllCoupons();
    CouponDto GetCouponById(int couponId);
    CouponDto GetCouponByCouponName(string couponName);
    CouponForUpdateDto GetCouponByForUpdate(int couponId);
    void CreateCoupon(CouponForCreationDto couponDto);
    void UpdateCoupon(CouponForUpdateDto couponDto);
    void DeleteCoupon(int couponId);
}