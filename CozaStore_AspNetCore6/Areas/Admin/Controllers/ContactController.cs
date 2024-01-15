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
    public class ContactController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ContactController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: Coupon
        public IActionResult Index()
        {
            var model = _serviceManager.ContactService.FindAllContacts();
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
        public IActionResult Create([FromForm] ContactForCreationDto contactForCreation)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ContactService.CreateContact(contactForCreation);
                return RedirectToAction(nameof(Index));
            }
            return View(contactForCreation);
        }

        // GET: Coupon/Edit/5
        public IActionResult Edit([FromRoute]int id)
        {
            var model = _serviceManager.ContactService.GetContactByIdForUpdateDto(id);
            return View(model);
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]ContactForUpdateDto contactForUpdate)
        {

            if (ModelState.IsValid)
            {
                _serviceManager.ContactService.UpdateContact(contactForUpdate);
                return RedirectToAction(nameof(Index));
            }
            return View(contactForUpdate);
        }

        // GET: Coupon/Delete/5
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                _serviceManager.ContactService.DeleteContact(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
