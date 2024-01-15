using DataAccess.Contracts;
using Entities.Models;

namespace DataAccess.Repository
{
    public class WishListRepository : RepositoryBase<WishList>, IWishListRepository
    {
        public WishListRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<WishList> WishLists => FindAll(false);
        
        public void CreateWishList(WishList wishlist)
        {
            Create(wishlist);
            _context.SaveChanges();
        }

        public void DeleteWishList(WishList wishlist)
        {
            Delete(wishlist);
            _context.SaveChanges();
        }

		public IQueryable<WishList> FindAllWishLists()
        {
            return FindAll(false);
        }

        public WishList GetWishListById(int? wishlistId)
        {
            return FindByCondition(wishlist => wishlist.Id.Equals(wishlistId), false);
        }

        public WishList? GetWishListByUserId(string UserId)
        {
            return FindIncludeByCondition(false,us => us.UserId == UserId,inc => inc.WishListProducts).FirstOrDefault();

        }

        public void UpdateWishList(WishList wishlist)
        {
            Update(wishlist);
            _context.SaveChanges();
        }
    }
}