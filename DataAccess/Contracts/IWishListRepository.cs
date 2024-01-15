using Entities.Models;

namespace DataAccess.Contracts
{
    public interface IWishListRepository : IRepositoryBase<WishList>
    {
        IQueryable<WishList> WishLists { get; }
        
        
		WishList GetWishListById(int? wishlistId);
        WishList? GetWishListByUserId(string UserId);
        void CreateWishList(WishList wishlist);
        void UpdateWishList(WishList wishlist);
        void DeleteWishList(WishList wishlist);
    }
}