using Business.Contracts;
using CozaStore_AspNetCore6.Models;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace CozaStore_AspNetCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _serviceManager;

		public HomeController(ILogger<HomeController> logger, IServiceManager serviceManager)
		{
			_logger = logger;
			_serviceManager = serviceManager;
		}

		public IActionResult Index(ProductRequestParameters productRequest, int loadMore = 0)
		{
			return GetProducts(productRequest, loadMore);
		}


		public IActionResult Product(ProductRequestParameters productRequest, int loadMore = 0)
		{
			return GetProducts(productRequest, loadMore);
		}
		public ViewResult GetProducts(ProductRequestParameters productRequest, int loadMore = 0)
		{
			var currentLoadMore = HttpContext.Session.GetInt32("loadMore") ?? loadMore;

			if (loadMore == 1)
			{
				currentLoadMore += 5;
			}

			HttpContext.Session.SetInt32("loadMore", currentLoadMore);

			ViewBag.LoadMore = currentLoadMore;
			productRequest.PageSize = 10;
			productRequest.PageSize += currentLoadMore;

			var allProducts = _serviceManager.ProductService.FindAllProducts(productRequest);
			var categories = _serviceManager.CategoryService.FindAllCategorys();
			var stocks = _serviceManager.StockService.FindAllStocksForFilter(productRequest.CategorySlug);
			var productsInStock = allProducts.Where(p => stocks.Any(s => s.ProductId == p.Id)).ToList();
			int count = _serviceManager.ProductService.CountProduct(productRequest);
			List<ProductDto> orderedProducts;
			if (productRequest.PageSize >= count)
			{
				var productsOutOfStock = allProducts.Where(p => !stocks.Any(s => s.ProductId == p.Id)).ToList();
				orderedProducts = productsInStock.Concat(productsOutOfStock).ToList();
			}
			else
			{
				orderedProducts = productsInStock;
			}
			Pagination pagination = new Pagination()
			{
				ItemsPerPage = productRequest.PageSize,
				TotalItems = orderedProducts.Count,
			};
			
			if (Request.Query.ContainsKey("CategorySlug"))
			{
				TempData["CategorySlug"] = Request.Query["CategorySlug"];
			}
			if (Request.Query.ContainsKey("SearchTerm"))
			{
				TempData["SearchTerm"] = Request.Query["SearchTerm"];
			}

			return View(new HomePageViewModel()
			{
				Pagination = pagination,
				Products = orderedProducts,
				Categories = categories,
				Stocks = stocks,
				productCount = count
			});
		}
        public IActionResult ProductDetail([FromRoute]string slug,[FromQuery] string size)
        {
			var model = _serviceManager.ProductService.GetProductWithSlug(slug, size);
			ViewBag.SelectedSize = size;
			Random rnd = new Random();
			var products = _serviceManager.ProductService.FindAllProductsWithoutParameters().OrderBy(x => rnd.Next()).Take(8).ToList();
			return View(new ProductDetailViewModel()
			{
				Product= model,
				Products = products,
			});
        }
		public IActionResult About()
		{
			var model = _serviceManager.AboutService.FindAllAbouts().FirstOrDefault();
			if (model is not null)
			{
				model.OurMission = Markdown.ToHtml(model.OurMission ?? string.Empty);
				model.OurStory = Markdown.ToHtml(model.OurStory ?? string.Empty);
			}
			return View(model);
		}
        public IActionResult Contact()
        {
			var model = _serviceManager.InformationService.FindAllInformations().FirstOrDefault();
            return View(model);
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult ContactCreate([FromForm]ContactForCreationDto contactForCreation)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ContactService.CreateContact(contactForCreation);
				return RedirectToAction(nameof(Contact));
            }
            return RedirectToAction(nameof(Contact));
		}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}