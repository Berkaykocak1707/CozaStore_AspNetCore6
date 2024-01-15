using Entities.Models;
using Entities.RequestParameters;

namespace DataAccess.Contracts
{
    public interface IStockRepository : IRepositoryBase<Stock>
    {
        IQueryable<Stock> Stocks { get; }
        IQueryable<Stock> StockFilterWithProductID(int productID);
        IQueryable<Stock> FindAllStocksForFilter(string categorySlug);
        IQueryable<Stock> FindAllStocks(StockRequestParameterscs stockRequest);
		List<string> FindAllColorWithProductAndSize(int productID,string size);
        Stock GetStockForCart(int productID,string size,string color);
        Stock GetStockById(int? stockId);
        void CreateStock(Stock stock);
        void UpdateStock(Stock stock);
        void DeleteStock(Stock stock);
	}
}