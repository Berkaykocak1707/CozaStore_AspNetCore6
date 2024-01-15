using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

public interface IStockService
{
    IEnumerable<StockDto> FindAllStocks(StockRequestParameterscs stockRequest);
    IEnumerable<StockDto> FindAllStocksForFilter(string categorySlug);
    IEnumerable<StockDto> FindAllColorWithProductAndSize(int productID, string size);
    StockDto GetStockForCart(int productID, string size, string color);
	int CountStock(int productID);
    StockDto GetStockById(int stockId);
    StockForUpdateDto GetStockByIdForUpdate(int stockId);
    void CreateStock(StockForCreationDto stockDto);
    void UpdateStock(StockForUpdateDto stockDto);
    void DeleteStock(int stockId);
}