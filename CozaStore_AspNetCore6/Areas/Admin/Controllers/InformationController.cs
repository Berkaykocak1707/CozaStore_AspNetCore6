using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOnly")]
    [Area("Admin")]
    public class InformationController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public InformationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: Information
        public IActionResult Index()
        {
            var model = _serviceManager.InformationService.FindAllInformations();
            return View(model);
        }

        // GET: Information/Edit/5
        public IActionResult Edit([FromRoute] int id)
        {
            var model = _serviceManager.InformationService.GetInformationByIdForUpdat(id);
            return View(model);
        }

        // POST: Information/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] InformationForUpdateDto information)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.InformationService.UpdateInformation(information);
                return RedirectToAction(nameof(Index));
            }
            return View(information);
        }
    }
}
