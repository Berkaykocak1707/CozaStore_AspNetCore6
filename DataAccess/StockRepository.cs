using DataAccess.Contracts;
using DataAccess.Extensions;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DataAccess.Repository
{
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Stock> Stocks => FindAll(false);
        
        public void CreateStock(Stock stock)
        {
            Create(stock);
            _context.SaveChanges();
        }

        public void DeleteStock(Stock stock)
        {
            Delete(stock);
            _context.SaveChanges();
        }

		public IQueryable<Stock> FindAllStocks(StockRequestParameterscs stockRequest)
        {
            return _context.Stocks.FindInclude(p => p.Product)
                                   .FilteredByProductId(stockRequest.ProductId)
                                   .ToPaginate(stockRequest.PageNumber, stockRequest.PageSize);
        }

        public IQueryable<Stock> FindAllStocksForFilter(string categorySlug)
        {
            if (categorySlug == null)
            {
				return FindIncludeByCondition(false, null, p => p.Product);
			}
            else
            {
				return _context.Stocks
                    .Include(p => p.Product)
                    .ThenInclude(c => c.Category)
                    .Where(c => c.Product.Category.Slug.Equals(categorySlug));
			}
            
        }

        public Stock GetStockById(int? stockId)
        {
            return _context.Stocks.FindByIdInclude(stockId,p => p.Product);
        }

		public Stock GetStockForCart(int productID, string size, string color)
		{
			return FindByCondition(s => s.ProductId.Equals(productID) && s.Size.Equals(size) && s.Color.Equals(color),false);
		}

		public IQueryable<Stock> StockFilterWithProductID(int productID)
		{
            return _context.Stocks.FilteredByProductId(productID);
		}

		public void UpdateStock(Stock stock)
        {
            Update(stock);
            _context.SaveChanges();
        }

		List<string> IStockRepository.FindAllColorWithProductAndSize(int productID, string size)
		{
			IQueryable<string> queryable = _context.Stocks.FindAllByCondition(p => p.ProductId == productID && p.Size == size).Select(c => c.Color);
			return queryable.ToList();
		}
	}
}