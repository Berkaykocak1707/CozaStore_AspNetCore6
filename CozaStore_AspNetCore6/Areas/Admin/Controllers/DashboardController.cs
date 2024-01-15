using Business.Contracts;
using CozaStore_AspNetCore6.Areas.Admin.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public DashboardController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(new DashboardModel()
            {
                Orders = _serviceManager.OrderService.GetAllOrders().Reverse().Take(5).ToList(),
                Products = _serviceManager.ProductService.FindAllProductsWithoutParameters(),
                Users = _serviceManager.AuthService.GetAllUsers(),
                Contacts = _serviceManager.ContactService.FindAllContacts().Take(3).ToList(),
            });
        }
    }
}