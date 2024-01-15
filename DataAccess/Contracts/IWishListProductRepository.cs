using Entities.Models;

namespace DataAccess.Contracts
{
    public interface IWishListProductRepository : IRepositoryBase<WishListProduct>
    {
        IQueryable<WishListProduct> WishListProducts { get; }
		IQueryable<WishListProduct> FindAllWishListProducts(int wishlistId);
        WishListProduct GetWishListProductById(int? wishlistproductId);
        void CreateWishListProduct(WishListProduct wishlistproduct);
        void UpdateWishListProduct(WishListProduct wishlistproduct);
        void DeleteWishListProduct(WishListProduct wishlistproduct);
    }
}