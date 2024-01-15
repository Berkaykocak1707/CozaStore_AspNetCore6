using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class CouponManager : ICouponService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CouponManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateCoupon(CouponForCreationDto couponDto)
        {
            var couponEntity = _mapper.Map<Coupon>(couponDto);
            _repositoryManager.Coupon.CreateCoupon(couponEntity);
        }

        public void DeleteCoupon(int couponId)
        {
            var coupon = _repositoryManager.Coupon.GetCouponById(couponId);
            _repositoryManager.Coupon.DeleteCoupon(coupon);
        }

        public IEnumerable<CouponDto> FindAllCoupons()
        {
            var coupon = _repositoryManager.Coupon.FindAll(false);
            var couponDto = _mapper.Map<IEnumerable<CouponDto>>(coupon);
            return couponDto;
        }


        public CouponForUpdateDto GetCouponByForUpdate(int couponId)
        {
            var coupon = _repositoryManager.Coupon.GetCouponById(couponId);
            var couponDto = _mapper.Map<CouponForUpdateDto>(coupon);
            return couponDto;
        }

        public CouponDto GetCouponById(int couponId)
        {
            var coupon = _repositoryManager.Coupon.GetCouponById(couponId);
            var couponDto = _mapper.Map<CouponDto>(coupon);
            return couponDto;
        }

        public CouponDto GetCouponByCouponName(string couponName)
        {
            var coupon = _repositoryManager.Coupon.GetCouponByCouponName(couponName);
            var couponDto = _mapper.Map<CouponDto>(coupon);
            return couponDto;
        }

        public void UpdateCoupon(CouponForUpdateDto couponDto)
        {
            var coupon = _mapper.Map<Coupon>(couponDto);
            _repositoryManager.Coupon.UpdateCoupon(coupon);
        }
    }
}