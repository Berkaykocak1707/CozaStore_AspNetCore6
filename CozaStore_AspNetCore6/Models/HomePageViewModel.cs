using Entities.Dtos;

namespace CozaStore_AspNetCore6.Models
{
	public class HomePageViewModel
	{
		public IEnumerable<ProductDto> Products
		{
		 get; set; } = Enumerable.Empty<ProductDto>();
		public IEnumerable<CategoryDto> Categories
		{
			get; set;
		} = Enumerable.Empty<CategoryDto>();
		public IEnumerable<StockDto> Stocks
		{
			get; set;
		} = Enumerable.Empty<StockDto>();
		public int productCount
		{
		 get; set; }
		public Pagination? Pagination
		{
			get; set;
		} = new();
		public int TotalCount => Products.Count();
	}
}
