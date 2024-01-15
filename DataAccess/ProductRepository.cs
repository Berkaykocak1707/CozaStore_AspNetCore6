using DataAccess.Contracts;
using DataAccess.Extensions;
using Entities.Models;
using Entities.RequestParameters;

namespace DataAccess.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Product> Products => FindAll(false);

		public int CountProduct(ProductRequestParameters productRequest)
		{
            return _context.Products
                           .FindInclude(c => c.Category)
                           .FilteredByCategorySlug(productRequest.CategorySlug)
                           .FilteredBySearchTerm(productRequest.SearchTerm)
                           .FilteredByColor(productRequest.Color)
                           .FilteredByPrice(productRequest.MinPrice, productRequest.MaxPrice, productRequest.IsValidPrice)
                           .FilteredSortBy(productRequest.SortBy)
                           .Count();
		}

		public void CreateProduct(Product product)
        {
            Create(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
            _context.SaveChanges();
        }


        public IQueryable<Product> FindAllProducts(ProductRequestParameters productRequest)
        {
            return _context.Products
                            .FindInclude(c => c.Category)
                            .FilteredByCategorySlug(productRequest.CategorySlug)
                            .FilteredBySearchTerm(productRequest.SearchTerm)
                            .FilteredByColor(productRequest.Color)
                            .FilteredByPrice(productRequest.MinPrice, productRequest.MaxPrice, productRequest.IsValidPrice)
                            .FilteredSortBy(productRequest.SortBy)
                            .ToPaginate(productRequest.PageNumber, productRequest.PageSize);
        }

        public IQueryable<Product> FindAllProductsWithCategory(ProductRequestParameters productRequest)
        {
            return FindInclude(false, c => c.Category)
                   .ToPaginate(productRequest.PageNumber, productRequest.PageSize);
        }

        public Product GetProductById(int? productId)
        {
            return FindByCondition(product => product.Id.Equals(productId), false);
        }


        public Product GetProductWithSlug(string slug)
        {
            return _context.Products
                .FindInclude(s => s.Stocks)
                .FindInclude(c => c.Category)
				.FindAllByCondition(s => s.Slug == slug)
				.FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
            _context.SaveChanges();
        }
    }
}