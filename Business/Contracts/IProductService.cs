using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using System.Globalization;

public interface IProductService
{
    IEnumerable<ProductDto> FindAllProducts(ProductRequestParameters productRequest);
    IEnumerable<ProductDto> FindAllProductsWithoutParameters();
    IEnumerable<ProductDto> FindAllProductsWithCategory(ProductRequestParameters productRequest);
    int CountProduct(ProductRequestParameters productRequest);
    ProductDto GetProductWithSlug(string slug,string size);
    ProductDto GetProductById(int productId);
    ProductForUpdateDto GetProductByIdForUpdate(int productId);
    int CreateProduct(ProductForCreationDto productDto);
    void UpdateProduct(ProductForUpdateDto productDto);
    void DeleteProduct(int productId);
}