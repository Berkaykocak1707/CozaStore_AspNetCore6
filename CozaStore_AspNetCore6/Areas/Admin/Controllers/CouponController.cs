using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CouponController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: Coupon
        public IActionResult Index()
        {
            var model = _serviceManager.CouponService.FindAllCoupons();
            return View(model);
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CouponForCreationDto couponForCreation)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.CouponService.CreateCoupon(couponForCreation);
                return RedirectToAction(nameof(Index));
            }
            return View(couponForCreation);
        }

        // GET: Coupon/Edit/5
        public IActionResult Edit([FromRoute]int id)
        {
            var model = _serviceManager.CouponService.GetCouponByForUpdate(id);
            return View(model);
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]CouponForUpdateDto couponForUpdate)
        {

            if (ModelState.IsValid)
            {
                _serviceManager.CouponService.UpdateCoupon(couponForUpdate);
                return RedirectToAction(nameof(Index));
            }
            return View(couponForUpdate);
        }

        // GET: Coupon/Delete/5
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                _serviceManager.CouponService.DeleteCoupon(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
