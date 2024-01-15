using Business.Contracts;
using CozaStore_AspNetCore6.Areas.Admin.Models;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using CozaStore_AspNetCore6.Models;
using Microsoft.AspNetCore.Authorization;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class StockController : Controller
    {
        readonly private IServiceManager _serviceManager;

        public StockController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: Stock
        public IActionResult Index([FromQuery] StockRequestParameterscs stockRequest)
        {
            var stocks = _serviceManager.StockService.FindAllStocks(stockRequest);
            var pagination = new Pagination()
            {
                ID = stockRequest.ProductId,
                CurrentPage = stockRequest.PageNumber,
                ItemsPerPage = stockRequest.PageSize,
                TotalItems = _serviceManager.StockService.CountStock(stockRequest.ProductId)
            };
            var stocksForFilter = _serviceManager.StockService.FindAllStocksForFilter(null);
            return View(new StockListViewModel()
            {
                Stocks = stocks,
                Pagination = pagination,
                StocksFilter = stocksForFilter
            });
        }


        // GET: Stock/Edit/5
        public IActionResult Edit([FromRoute]int id)
        {
            var model = _serviceManager.StockService.GetStockByIdForUpdate(id);
            return View(model);
        }

        // POST: Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] StockForUpdateDto stockForUpdate)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.StockService.UpdateStock(stockForUpdate);
                return RedirectToAction(nameof(Index));
            }
            return View(stockForUpdate);
        }

        // GET: Stock/Delete/5
        public IActionResult Delete([FromRoute]int id)
        {
            _serviceManager.StockService.DeleteStock(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
