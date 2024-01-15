using CozaStore_AspNetCore6.Models;
using Entities.Dtos;
using Entities.Models;

namespace CozaStore_AspNetCore6.Areas.Admin.Models
{
    public class StockListViewModel
    {
        public IEnumerable<StockDto>? Stocks
        {
            get;
            set;
        } = Enumerable.Empty<StockDto>();
        public IEnumerable<StockDto>? StocksFilter
        {
            get;
            set;
        } = Enumerable.Empty<StockDto>();
        public Pagination? Pagination
        {
            get; set;
        } = new();
        public int TotalCount => Stocks.Count();
    }
}
