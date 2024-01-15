using Business;
using Business.Contracts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        readonly private IServiceManager _serviceManager;
        readonly private SlugService _slugService;


        public CategoryController(IServiceManager serviceManager, SlugService slugService)
        {
            _serviceManager = serviceManager;
            _slugService = slugService;
        }

        // GET: Category
        public IActionResult Index()
        {
            var model = _serviceManager.CategoryService.FindAllCategorys();
            return View(model);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]CategoryForCreationDto categoryForCreation)
        {
            if (categoryForCreation.Name != null)
            {
                var slug = _slugService.GenerateSlug(categoryForCreation.Name);
                categoryForCreation.Slug = slug;
                _serviceManager.CategoryService.CreateCategory(categoryForCreation);
                return RedirectToAction(nameof(Index));
            }
            
            return View(categoryForCreation);
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int id)
        {
            var model = _serviceManager.CategoryService.GetCategoryByIdForUpdate(id);
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] CategoryForUpdateDto categoryForUpdate)
        {
            if(categoryForUpdate.Name != null)
            {
                var slug = _slugService.GenerateSlug(categoryForUpdate.Name);
                categoryForUpdate.Slug = slug;
                _serviceManager.CategoryService.UpdateCategory(categoryForUpdate);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryForUpdate);
        }

        // GET: Category/Delete/5
        public IActionResult Delete([FromRoute] int id)
        {
            _serviceManager.CategoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
