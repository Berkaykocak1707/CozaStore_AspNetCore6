using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Business
{
    public class StockManager : IStockService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public StockManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

		public int CountStock(int productID)
		{
            return _repositoryManager.Stock.StockFilterWithProductID(productID).Count();
		}

		public void CreateStock(StockForCreationDto stockDto)
        {
            var stockEntity = _mapper.Map<Stock>(stockDto);
            _repositoryManager.Stock.CreateStock(stockEntity);
        }

        public void DeleteStock(int stockId)
        {
            var stock = _repositoryManager.Stock.GetStockById(stockId);
            _repositoryManager.Stock.DeleteStock(stock);
        }

		public IEnumerable<StockDto> FindAllColorWithProductAndSize(int productID, string size)
		{
			var stock = _repositoryManager.Stock.FindAllColorWithProductAndSize(productID, size);
            var stockDto = _mapper.Map<IEnumerable<StockDto>>(stock);

			return stockDto;
		}

		public IEnumerable<StockDto> FindAllStocks(StockRequestParameterscs stockRequest)
        {
            var stock = _repositoryManager.Stock.FindAllStocks(stockRequest);
            var stockDto = _mapper.Map<IEnumerable<StockDto>>(stock);
            return stockDto;
        }

        public IEnumerable<StockDto> FindAllStocksForFilter(string categorySlug)
        {
            var stock = _repositoryManager.Stock.FindAllStocksForFilter(categorySlug);
            var stockDto = _mapper.Map<IEnumerable<StockDto>>(stock);
            return stockDto;
        }

        public StockDto GetStockById(int stockId)
        {
            var stock = _repositoryManager.Stock.GetStockById(stockId);
            var stockDto = _mapper.Map<StockDto>(stock);
            return stockDto;
        }

        public StockForUpdateDto GetStockByIdForUpdate(int stockId)
        {
            var stock = _repositoryManager.Stock.GetStockById(stockId);
            var stockDto = _mapper.Map<StockForUpdateDto>(stock);
            return stockDto;
        }

		public StockDto GetStockForCart(int productID, string size, string color)
		{
			var stock = _repositoryManager.Stock.GetStockForCart(productID, size, color);
            var stockDto = _mapper.Map<StockDto>(stock);
            return stockDto;
		}

		public void UpdateStock(StockForUpdateDto stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            _repositoryManager.Stock.UpdateStock(stock);
        }
    }
}