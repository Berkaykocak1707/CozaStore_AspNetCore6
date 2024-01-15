using DataAccess.Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
	public class WishListProductRepository : RepositoryBase<WishListProduct>, IWishListProductRepository
	{
        public WishListProductRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<WishListProduct> WishListProducts => FindAll(false);
        
        public void CreateWishListProduct(WishListProduct wishlistproduct)
        {
			try
			{
				Create(wishlistproduct);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw;
			}
			
        }

        public void DeleteWishListProduct(WishListProduct wishlistproduct)
        {
            Delete(wishlistproduct);
            _context.SaveChanges();
        }

        public IQueryable<WishListProduct> FindAllWishListProducts()
        {
            return FindAll(false);
        }

		public IQueryable<WishListProduct> FindAllWishListProducts(int wishlistId)
		{
			return _context.WishListProducts
				 .Where(wlp => wlp.WishListId == wishlistId)
				 .Include(wlp => wlp.Product);
		}

		public WishListProduct GetWishListProductById(int? wishlistproductId)
        {
            return FindByCondition(wishlistproduct => wishlistproduct.WishListId.Equals(wishlistproductId), false);
        }

        public void UpdateWishListProduct(WishListProduct wishlistproduct)
        {
            Update(wishlistproduct);
            _context.SaveChanges();
        }
    }
}