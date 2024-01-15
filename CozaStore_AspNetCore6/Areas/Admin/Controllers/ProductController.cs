using Business;
using Business.Contracts;
using CozaStore_AspNetCore6.Areas.Admin.Controllers;
using CozaStore_AspNetCore6.Areas.Admin.Models;
using Entities.Dtos;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using CozaStore_AspNetCore6.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly SlugService _slug;

        public ProductController(IServiceManager serviceManager, SlugService slug)
        {
            _serviceManager = serviceManager;
            _slug = slug;
        }
        private SelectList GetCategorySelectList()
        {
            return new SelectList(_serviceManager.CategoryService.FindAllCategorys(), "Id", "Name", "1");
        }
        // GET: Product
        public IActionResult Index([FromQuery] ProductRequestParameters productRequest)
        {
            productRequest.PageSize = 5;
            var products = _serviceManager.ProductService.FindAllProductsWithCategory(productRequest);
            var pagination = new Pagination()
            {
                CurrentPage = productRequest.PageNumber,
                ItemsPerPage = productRequest.PageSize,
                TotalItems = _serviceManager.ProductService.CountProduct(productRequest)
            };
            return View(new ProductListViewModel()
            {
                Pagination = pagination,
                Products = products
            });
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewBag.Category = GetCategorySelectList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ProductForCreationDto productForCreation,IFormFile photo, IFormFile? photo2, IFormFile? photo3)
        {
            if (productForCreation is not null && productForCreation.Name is not null)
            {
                var productSlug = _slug.GenerateSlug(productForCreation.Name);
                productForCreation.Slug = productSlug;
                ModelState.SetModelValue("Slug", new ValueProviderResult(productForCreation.Slug));
                var url = await PhotoInsertAsync(photo, productSlug);
                productForCreation.Photo1Url = String.Concat("/img/", url);
                ModelState.SetModelValue("Photo1Url", new ValueProviderResult(productForCreation.Photo1Url));
                if (photo2 is not null)
                {
                    var url2 = await PhotoInsertAsync(photo2, productSlug);
                    productForCreation.Photo2Url = String.Concat("/img/", url2);
                }
                if (photo3 is not null)
                {
                    var url3 = await PhotoInsertAsync(photo3, productSlug);
                    productForCreation.Photo3Url = String.Concat("/img/", url3);
                }
                ModelState.Clear();
                if (ModelState.IsValid)
                {

                    var ProductId = _serviceManager.ProductService.CreateProduct(productForCreation);
                    foreach (var item in productForCreation.Stocks)
                    {
                            var model = new StockForCreationDto()
                            {   
                                ProductId = ProductId,
                                Color = item.Color,
                                Size = item.Size,
                                Quantity = item.Quantity,
                            };
                            _serviceManager.StockService.CreateStock(model);

                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {

            }
            ViewBag.Category = GetCategorySelectList();
            
            return View(productForCreation);
        }
        private async Task<string> PhotoInsertAsync(IFormFile file,string slug)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 101);
            // file operation
            string originalFileName = file.FileName;
            string fileExtension = Path.GetExtension(originalFileName);
            string newFileName = slug + randomNumber + fileExtension;
            string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "img", newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return newFileName;

        }
        // GET: Product/Edit/5
        public IActionResult Edit([FromRoute] int id)
        {
            if (id != null)
            {
                var model = _serviceManager.ProductService.GetProductByIdForUpdate(id);
                ViewBag.Category = GetCategorySelectList();
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync([FromForm] ProductForUpdateDto productForUpdate,string Photo1Url, string Photo2Url, string Photo3Url, IFormFile photo, IFormFile? photo2, IFormFile? photo3, bool deletePhoto2, bool deletePhoto3)
            {
            if (productForUpdate is not null && productForUpdate.Name is not null)
            {
                var productSlug = _slug.GenerateSlug(productForUpdate.Name);
                productForUpdate.Slug = productSlug;
                ModelState.SetModelValue("Slug", new ValueProviderResult(productForUpdate.Slug));
                if (photo is not null )
                {
                    var url = await PhotoInsertAsync(photo, productSlug);
                    productForUpdate.Photo1Url = String.Concat("/img/", url);
                    ModelState.SetModelValue("Photo1Url", new ValueProviderResult(productForUpdate.Photo1Url));
                }
                else
                {
                    productForUpdate.Photo1Url = Photo1Url;
                    ModelState.SetModelValue("Photo1Url", new ValueProviderResult(productForUpdate.Photo1Url));
                }
                if (photo2 is not null)
                {
                    var url2 = await PhotoInsertAsync(photo2, productSlug);
                    productForUpdate.Photo2Url = String.Concat("/img/", url2);
                }
                else if (deletePhoto2 == true)
                {
                    productForUpdate.Photo2Url = null;
                }
                else
                {
                    productForUpdate.Photo2Url = Photo2Url;
                }
                if (photo3 is not null)
                {
                    var url3 = await PhotoInsertAsync(photo3, productSlug);
                    productForUpdate.Photo3Url = String.Concat("/img/", url3);
                }
                else if (deletePhoto3 == true)
                {
                    productForUpdate.Photo3Url = null;
                }
                else
                {
                    productForUpdate.Photo3Url = Photo3Url;
                }
                ModelState.Clear();
                if (ModelState.IsValid)
                {

                    var ProductId = productForUpdate.Id;
                    _serviceManager.ProductService.UpdateProduct(productForUpdate);
                    foreach (var item in productForUpdate.Stocks)
                    {
                            var model = new StockForCreationDto()
                            {
                                ProductId = ProductId,
                                Color = item.Color,
                                Size = item.Size,
                                Quantity = item.Quantity,
                            };
                            _serviceManager.StockService.CreateStock(model);

                    }
                    return RedirectToAction(nameof(Index));
                }
            }
                ViewBag.Category = GetCategorySelectList();
            return View(productForUpdate);
        }

        // GET: Product/Delete/5
        public IActionResult Delete([FromRoute]int id)
        {
            if (id != null)
            {
                _serviceManager.ProductService.DeleteProduct(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

