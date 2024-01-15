using AutoMapper;
using Business.Contracts;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Business
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public int CountProduct(ProductRequestParameters productRequest)
        {
            return _repositoryManager.Product.CountProduct(productRequest);
        }

        public int CreateProduct(ProductForCreationDto productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.CreateProduct(productEntity);
            return productEntity.Id;
        }

        public void DeleteProduct(int productId)
        {
            var product = _repositoryManager.Product.GetProductById(productId);
            _repositoryManager.Product.DeleteProduct(product);
        }

        public IEnumerable<ProductDto> FindAllProducts(ProductRequestParameters productRequest)
        {
            var product = _repositoryManager.Product.FindAllProducts(productRequest);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);
            return productDto;
        }

        public IEnumerable<ProductDto> FindAllProductsWithCategory(ProductRequestParameters productRequest)
        {
            var product = _repositoryManager.Product.FindAllProductsWithCategory(productRequest);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);
            return productDto;
        }

        public IEnumerable<ProductDto> FindAllProductsWithoutParameters()
        {
            var product = _repositoryManager.Product.Products;
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);
            return productDto;
        }

        public ProductDto GetProductById(int productId)
        {
            var product = _repositoryManager.Product.GetProductById(productId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public ProductForUpdateDto GetProductByIdForUpdate(int productId)
        {
            var product = _repositoryManager.Product.GetProductById(productId);
            var productDto = _mapper.Map<ProductForUpdateDto>(product);
            return productDto;
        }

        public ProductDto GetProductWithSlug(string slug,string size)
        {
            var product = _repositoryManager.Product.GetProductWithSlug(slug);
            var productDto = _mapper.Map<ProductDto>(product);
            if (size is not null)
            {
				productDto.AvailableSizes = _repositoryManager.Stock.FindAllColorWithProductAndSize((int)productDto.Id, size);
			}
            
            return productDto;
        }

        public void UpdateProduct(ProductForUpdateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _repositoryManager.Product.UpdateProduct(product);
        }
    }
}