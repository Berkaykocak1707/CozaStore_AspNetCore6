using Entities.Dtos;

namespace CozaStore_AspNetCore6.Models
{
    public class ProductDetailViewModel
    {
        public IEnumerable<ProductDto> Products
        {
            get; set;
        } = Enumerable.Empty<ProductDto>();
        public ProductDto Product
        {
        get; set; }
    }
}
