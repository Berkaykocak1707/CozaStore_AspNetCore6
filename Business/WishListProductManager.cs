using AutoMapper;
using Business.Contracts;
using DataAccess;
using DataAccess.Contracts;
using Entities.Dtos;
using Entities.Models;

namespace Business
{
    public class WishListProductManager : IWishListProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WishListProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void CreateWishListProduct(WishListProductForCreationDto wishlistproductDto)
        {
            var wishlistproductEntity = _mapper.Map<WishListProduct>(wishlistproductDto);
            _repositoryManager.WishListProduct.CreateWishListProduct(wishlistproductEntity);
            _repositoryManager.Save();
        }

        public void DeleteWishListProduct(int wishlistproductId)
        {
            var wishlistproduct = _repositoryManager.WishListProduct.GetWishListProductById(wishlistproductId);
            _repositoryManager.WishListProduct.DeleteWishListProduct(wishlistproduct);
            _repositoryManager.Save();
        }

        public void AddProductToWishList(WishListProductForCreationDto wishlistproductDto)
        {
            var wishlistproductEntity = _mapper.Map<WishListProduct>(wishlistproductDto);
            _repositoryManager.WishListProduct.CreateWishListProduct(wishlistproductEntity);
            _repositoryManager.Save();
        }

        public void RemoveProductFromWishList(int wishlistId, int wishlistproductId)
        {
            var wishlistproduct = _repositoryManager.WishListProduct.FindByCondition(wp => wp.WishListId == wishlistId && wp.ProductId == wishlistproductId,false);
            if (wishlistproduct != null)
            {
                _repositoryManager.WishListProduct.Delete(wishlistproduct);
                _repositoryManager.Save();
            }
        }
        public void DeleteWishListProductsByListId(int wishlistId)
        {
            var wishlistProducts = _repositoryManager.WishListProduct
                          .FindAllByCondition(false,wp => wp.WishListId == wishlistId)
                          .ToList();
            foreach (var product in wishlistProducts)
            {
                _repositoryManager.WishListProduct.Delete(product);
            }
            _repositoryManager.Save();
        }

		public WishListProductDto GetWishListProductById(int wishlistId, int? wishlistproductId)
		{
            var entity = _repositoryManager.WishListProduct.FindByCondition(wp => wp.WishListId == wishlistId && wp.ProductId == wishlistproductId, false);
			var dto = _mapper.Map<WishListProductDto>(entity);
            return dto;
		}

		public IEnumerable<WishListProductDto> FindAllWishListProducts(int wishlistId)
		{
            var entity = _repositoryManager.WishListProduct.FindAllWishListProducts(wishlistId);
            var dto = _mapper.Map<IEnumerable<WishListProductDto>>(entity);
            return dto;
		}
	}
}
