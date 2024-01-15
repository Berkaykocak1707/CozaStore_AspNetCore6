using CozaStore_AspNetCore6.Models;
using Entities.Dtos;

namespace CozaStore_AspNetCore6.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductDto>? Products
        {
            get; set;
        } = Enumerable.Empty<ProductDto>();
        public Pagination? Pagination
        {
            get; set;
        } = new();
        public int TotalCount => Products.Count();
    }
}
