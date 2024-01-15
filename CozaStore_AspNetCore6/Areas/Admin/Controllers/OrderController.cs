using Business.Contracts;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using CozaStore_AspNetCore6.Models;
using Microsoft.AspNetCore.Authorization;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] OrderRequestParameters requestParameters)
        {
            var orders = _manager.OrderService.GetOrdersWithParameters(requestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = _manager.OrderService.GetAllOrders().Count()
            };
            return View(new OrderListViewModel()
            {
                Orders = orders,
                Pagination = pagination
            });
        }

        public IActionResult Complete([FromRoute] int id)
        {
            _manager.OrderService.MarkAsShipped(id);
            return RedirectToAction("Index");
        }
    }
}
