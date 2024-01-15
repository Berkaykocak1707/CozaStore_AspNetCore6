using Business.Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Components
{
	public class WhisListSummaryViewComponent : ViewComponent
	{
		private readonly IServiceManager _serviceManager;
		private readonly UserManager<CustomUser> _userManager;
		public WhisListSummaryViewComponent(IServiceManager repositoryContext, UserManager<CustomUser> userManager)
		{
			_serviceManager = repositoryContext;
			_userManager = userManager;
		}
		public string Invoke()
		{
			var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
			if (userId == null)
			{
				return "0";
			}
			else
			{
				var whisList = _serviceManager.WishListService.GetWishListByUserId(userId);
				if (whisList == null)
				{
					return "0";
				}
				else
				{
					return _serviceManager.WishListProductService.FindAllWishListProducts((int)whisList.Id).Count().ToString();
				}
			}
		}
	}
}
