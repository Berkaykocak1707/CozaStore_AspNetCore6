using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;
        private readonly UserManager<CustomUser> _userManager;

        public OrderController(IServiceManager manager, Cart cart, UserManager<CustomUser> userManager)
        {
            _manager = manager;
            _cart = cart;
            _userManager = userManager;
        }
        [ValidateAntiForgeryToken]
        public IActionResult Checkout([FromForm] string line1,string line2, string city ,bool giftWrap,decimal subTotal,string couponName = "Coupon didn't used",int couponDiscount = 0)
        {
            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sepete ürün ekle");
            }
            var userIdValue = _userManager.GetUserId(User);
            var subQuantity = 0;
            foreach (var item in _cart.Lines)
            {
                subQuantity += item.Quantity;
            }
               
            var order = new OrderDtoForCreation()
            {
                UserId = userIdValue,
                Name = User.Identity.Name,
                Line1 = line1,
                Line2 = line2,
                City = city,
                GiftWrap = giftWrap,
                SubTotal = subTotal,
                SubTotalQuantity = subQuantity,
                CouponDiscount = couponDiscount,
                CouponName = couponName
                
            };
            ModelState.Remove("CouponName");
            ModelState.Remove("CouponDiscount");

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                var orderModel =_manager.OrderService.CreateOrder(order);
                var orderId = orderModel.OrderId;
                TempData["OrderId"] = orderId;
                _cart.Clear();
                if (couponName != "Coupon didn't used")
                {
                    var coupon = _manager.CouponService.GetCouponByCouponName(couponName);
                    var couponStock = coupon.CouponStock -= 1;
                    var couponModel = new CouponForUpdateDto()
                    {
                        CouponCode = coupon.CouponCode,
                        CouponStock = couponStock,
                        CouponDiscountPercentage = coupon.CouponDiscountPercentage,
                        CouponId = coupon.CouponId,
                        EndDate = coupon.EndDate,
                        IsActive = coupon.IsActive,
                    };
                    _manager.CouponService.UpdateCoupon(couponModel);
                }
               
                return RedirectToPage("/Complete");
            }
            return View();
        }
    }
}
