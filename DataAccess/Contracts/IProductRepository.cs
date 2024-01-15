using DataAccess.Extensions;
using Entities.Models;
using Entities.RequestParameters;

namespace DataAccess.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> Products { get; }
        
        IQueryable<Product> FindAllProducts(ProductRequestParameters productRequest);
        IQueryable<Product> FindAllProductsWithCategory(ProductRequestParameters productRequest);
		int CountProduct(ProductRequestParameters productRequest);
		Product GetProductById(int? productId);
        Product GetProductWithSlug(string slug);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}