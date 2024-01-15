using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Controllers
{
    [Authorize]
    public class WhisListController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<CustomUser> _userManager;

		public WhisListController(IServiceManager serviceManager, UserManager<CustomUser> userManager)
		{
			_serviceManager = serviceManager;
			_userManager = userManager;
		}

		public IActionResult Index()
        {
			var userId = _userManager.GetUserId(User);
            var whisList = _serviceManager.WishListService.GetWishListByUserId(userId);
            if (whisList is null)
            {
                return Redirect("/");
            }
            var model = _serviceManager.WishListProductService.FindAllWishListProducts((int)whisList.Id);
            return View(model);
        }
        public IActionResult AddWishList([FromQuery] int productId, string returnUrl = "/" )
        {
             var userId = _userManager.GetUserId(User);
             var whisList = _serviceManager.WishListService.GetWishListByUserId(userId);
            if (whisList == null)
            {
               var data =  new WishListForCreationDto()
                {
                    UserId = userId
                };
                _serviceManager.WishListService.CreateWishList(data);
                whisList = _serviceManager.WishListService.GetWishListByUserId(userId);
            }
            var product = _serviceManager.WishListProductService.GetWishListProductById((int)whisList.Id,productId);
            if (product == null)
            {
				var data2 = new WishListProductForCreationDto()
				{
					ProductId = productId,
					WishListId = whisList.Id
				};
				_serviceManager.WishListProductService.AddProductToWishList(data2);
			}
            return Redirect(returnUrl);
        }
		public IActionResult RemoveWishList([FromQuery] int productId, string returnUrl = "/")
		{
			var userId = _userManager.GetUserId(User);
			var whisList = _serviceManager.WishListService.GetWishListByUserId(userId);
			if (whisList is null)
			{
				return Redirect("/");
			}
			_serviceManager.WishListProductService.RemoveProductFromWishList((int)whisList.Id,productId);
			return Redirect(returnUrl);
		}
	}
}
