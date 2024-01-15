using Business.Contracts;
using CozaStore_AspNetCore6.Models;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		private readonly UserManager<CustomUser> _userManager;
		private readonly IServiceManager _manager;

		public UserController(UserManager<CustomUser> userManager, IServiceManager serviceManager)
		{
			_userManager = userManager;
			_manager = serviceManager;
		}
		public IActionResult Index([FromQuery] OrderRequestParameters requestParameters)
		{
			var UserID = _userManager.GetUserId(User);
			requestParameters.UserId = UserID;
			requestParameters.PageSize = 4;
			var orders = _manager.OrderService.FindAllOrdersWithUserId(requestParameters);
			var orderCounts = _manager.OrderService.OrderCount(UserID);
			TempData["ShippedCounts"] = orderCounts.Count(c => c.Shipped == true);
            TempData["ProgressCounts"] = orderCounts.Count(c => c.Shipped == false);
            if (Request.Query.ContainsKey("Shipped"))
			{
				string shippedValue = Request.Query["Shipped"];

				bool? shippedBool = null; // Nullable bool, varsayılan olarak null

				if (!string.IsNullOrEmpty(shippedValue))
				{
					// String değeri boolean'a dönüştür
					if (bool.TryParse(shippedValue, out bool parsedValue))
					{
						shippedBool = parsedValue;
					}
				}

				TempData["Shipped"] = shippedBool;
			}
			int orderCountspagination = 0;
			if (requestParameters.Shipped == null)
			{
				orderCountspagination = orderCounts.Count();
			}
			else
			{
				orderCountspagination = orderCounts.Count(s => s.Shipped == requestParameters.Shipped);
			}
			var pagination = new Pagination()
			{
				CurrentPage = requestParameters.PageNumber,
				ItemsPerPage = requestParameters.PageSize,
				TotalItems = orderCountspagination
			};
			return View(new OrderListViewModel()
			{
				Orders = orders,
				Pagination = pagination
			});
		}
		public IActionResult OrderDetail([FromRoute] int slug)
		{
			var OrderId = TempData["OrderId"];
			var model = _manager.OrderService.GetOrderById(slug);
			return View(model);
		}
	}
}
